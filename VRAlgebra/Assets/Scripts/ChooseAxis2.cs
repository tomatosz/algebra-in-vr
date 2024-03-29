using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ChooseAxis2 : MonoBehaviour
{
    // Identical to ChooseAxis.cs, except the static variables have a 2 so it can generate a second list for a second object in the same scene

    public float rotationSpeed = 0.2f;
    static public Quaternion[] allRotations2 = GenerateRotationsCube();
    public Vector3 axis = new Vector3(0, 1, 0);

    static private string[] selectedAxis2 = { "r", "t", "s" };
    private int axisIndex = 0;
    public string axisName = selectedAxis2[0];
    private Vector3[] axisList = { new Vector3(0, 1, 0), new Vector3(0, 1, 1), new Vector3(1, 1, 1) };

    //public Renderer = rendering;
    public bool canChangeAxis = true;
    private Quaternion previousRotation;
    public static List<string> actions2 = new List<string>();

    public InputActionProperty ToggleAxis1;
    public InputActionProperty ToggleAxis2;
    public InputActionProperty ResetButton;

    public InputActionProperty rightHandVelocity;
    public GameObject PlayerPosition;
    public Vector3 velocity { get; private set; } = new Vector3(3f, 3f, 3f);

    private bool isTriggerPressed = false;
    private Quaternion StartPosition;

    void Start()
    {
        StartPosition = this.transform.rotation;
    }
    void Update()
    {
        //Change the axis depending on which button you press
        if (ToggleAxis1.action.WasPressedThisFrame())
        {
            if (canChangeAxis == true)
            {
                axisIndex = (axisIndex + 1) % 3;
                axisName = selectedAxis2[axisIndex];
                axis = axisList[axisIndex];
            }

        }

        if (ToggleAxis2.action.WasPressedThisFrame())
        {
            if (canChangeAxis == true)
            {
                axisIndex = (axisIndex + 2) % 3;
                axisName = selectedAxis2[axisIndex];
                axis = axisList[axisIndex];
            }
        }

        if (ResetButton.action.WasPressedThisFrame())
        {
            actions2.Clear();
            this.transform.rotation = StartPosition;
        }

        if (Input.GetKeyDown("p"))
        {
            string result = "";
            if (actions2.Count > 0)
            {
                for (int k = actions2.Count - 1; k >= 0; k--)
                    result += actions2[k];
            }
        }
        velocity = rightHandVelocity.action.ReadValue<Vector3>();
        if (isTriggerPressed == true)
        {

            float YaxisRotation = 0f;
            float XaxisRotation = 0f;
            Debug.Log(velocity.ToString());
            if (Math.Abs(velocity.x) > 0.1 * Math.Abs(velocity.y))
                XaxisRotation = -velocity.x * rotationSpeed;
            if (Math.Abs(velocity.y) > 0.1 * Math.Abs(velocity.x))
                YaxisRotation = velocity.y * rotationSpeed;

            //select the axis by which you want to rotate the GameObject
            transform.RotateAround(axis, XaxisRotation);
        }
    }

    public void OnTriggerDrag()
    {

        isTriggerPressed = true;
        canChangeAxis = false;
        //Save our current rotation to recognize what rotation we eventualy did
        if (canChangeAxis == true)
        {
            previousRotation = transform.rotation;
        }
    }
    public void OnTriggerUp()
    {
        isTriggerPressed = false;
        //Magnetize to a symmetry if we are close enough and check what rotation we did
        Quaternion closest = ClosestRotation(allRotations2);
        //StartCoroutine(PerformRotation(closest));

        if (Quaternion.Angle(transform.rotation, closest) < 20)
        {
            StartCoroutine(PerformRotation(closest));
            AddRotations(previousRotation, closest);
            previousRotation = closest;
            canChangeAxis = true;
        }

    }


    //Perform the rotation to a target rotation
    IEnumerator PerformRotation(Quaternion targetRotation)
    {
        float progress = 0f;
        float speed = 0.3f;

        while (progress < 1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, progress);
            progress += Time.deltaTime * speed;
            if (progress <= 1f)
            {
                yield return null;
            }
        }
    }


    //Generate all rotations for the cube/octahedron
    static Quaternion[] GenerateRotationsCube()
    {
        Quaternion[] allRotations = new Quaternion[24];
        //
        for (int i = 0; i <= 3; i++)
            allRotations[i] = Quaternion.AngleAxis(i * 90, new Vector3(0, 1, 0));
        for (int i = 0; i <= 2; i++)
            allRotations[i + 4] = Quaternion.AngleAxis(90 + i * 90, new Vector3(1, 0, 0));
        for (int i = 0; i <= 2; i++)
            allRotations[i + 7] = Quaternion.AngleAxis(90 + i * 90, new Vector3(0, 0, 1));
        //
        for (int i = 0; i <= 2; i++)
            allRotations[i + 10] = Quaternion.AngleAxis(180, new Vector3((i + 1) % 3 - 1, (i + 2) % 3 - 1, i % 3 - 1));
        for (int i = 0; i <= 2; i++)
            allRotations[i + 13] = Quaternion.AngleAxis(180, new Vector3(((i + 2) % 3 - 1) * ((i + 2) % 3 - 1), ((i + 1) % 3 - 1) * ((i + 1) % 3 - 1), (i % 3 - 1) * (i % 3 - 1)));
        //
        for (int i = 0; i <= 1; i += 1)
        {
            allRotations[4 * i + 16] = Quaternion.AngleAxis(120 + 120 * i, new Vector3(-1, -1, 1));
            allRotations[4 * i + 17] = Quaternion.AngleAxis(120 + 120 * i, new Vector3(-1, 1, 1));
            allRotations[4 * i + 18] = Quaternion.AngleAxis(120 + 120 * i, new Vector3(1, -1, 1));
            allRotations[4 * i + 19] = Quaternion.AngleAxis(120 + 120 * i, new Vector3(1, 1, 1));
        }

        return allRotations;
    }

    //Finded the nearest Rotation
    Quaternion ClosestRotation(Quaternion[] rotations)
    {
        Quaternion closest = rotations[0];
        for (int i = 1; i < rotations.Length; i++)
        {
            if (Quaternion.Angle(transform.rotation, rotations[i]) < Quaternion.Angle(transform.rotation, closest))
                closest = rotations[i];
        }
        return closest;
    }

    //Add the rotation we did to the list of rotations
    void AddRotations(Quaternion start, Quaternion end)
    {
        //string result = "";

        if (axisIndex == 0)
        {
            float angle = (((end.eulerAngles.y + 360) % 360) - ((start.eulerAngles.y + 360) % 360) + 360) % 360;
            for (float i = 0f; i < angle / 90; i++)
            {
                actions2.Add("r");
            }
        }

        else if (axisIndex == 1)
        {
            if (start != end)
                actions2.Add("t");
        }

        else if (axisIndex == 2)
        {
            int amount = 0;

            for (int k = 0; k < 3; k++)
            {
                if (Quaternion.Angle(end, (Quaternion.AngleAxis(120 * k, new Vector3(1, 1, 1))) * start) == 0)
                {
                    amount = k;
                }
            }
            for (int j = 0; j < amount; j++)
                actions2.Add("s");

        }
        //for (int k = actions.Count - 1; k >= 0; k--)
        //  result += actions[k];

        //return result;
    }
}