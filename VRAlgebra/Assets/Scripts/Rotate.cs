using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Rotate : MonoBehaviour
{

    public float rotationSpeed = 0.2f;
    static public Quaternion[] allRotations = GenerateRotationsCube();
    static public bool MenuOn = false;
    //public Renderer = rendering;

    public Material transparant;

    //VR
    public InputActionProperty rightHandVelocity;
    public GameObject PlayerPosition;
    public Vector3 velocity { get; private set; } = new Vector3(3f, 3f, 3f);

    private bool isTriggerPressed = false;


    

    //Go back to original state
    void OnMouseUp()
    {
        
    }
    void Update()
    {
        velocity = rightHandVelocity.action.ReadValue<Vector3>();
        if (isTriggerPressed == true)
        {
            float YaxisRotation = 0f;
            float XaxisRotation = 0f;
            Debug.Log(velocity.ToString());
            if (Math.Abs(velocity.x) > 0.1 * Math.Abs(velocity.y))
                XaxisRotation = velocity.x * rotationSpeed;
            if (Math.Abs(velocity.y) > 0.1 * Math.Abs(velocity.x))
                YaxisRotation = velocity.y * rotationSpeed;

            //select the axis by which you want to rotate the GameObject
            transform.RotateAround(Vector3.down, XaxisRotation);
            transform.RotateAround(new Vector3(-(PlayerPosition.transform.position.z - this.transform.position.z), 0, PlayerPosition.transform.position.x - this.transform.position.x), YaxisRotation);
            this.GetComponent<Renderer>().material = transparant;
        }

    }

    //Rotate the object with the mouse
    public void OnTriggerDrag()
    {

        isTriggerPressed = true;
        

    }

    //Go back to original state
    public void OnTriggerUp()
    {
        isTriggerPressed = false;
        Quaternion closest = ClosestRotation(allRotations);
        if (Quaternion.Angle(transform.rotation, closest) < 20)
        {
            this.GetComponent<Renderer>().material.color = Color.green;
            StartCoroutine(PerformRotation(closest));
        }

        else
        {
            this.GetComponent<Renderer>().material.color = Color.red;
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
}

