using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAxis : MonoBehaviour
{

    public float rotationSpeed = 0.2f;
    static public Quaternion[] allRotations = GenerateRotationsCube();
    public Vector3 axis = new Vector3(0, 1, 0);

    static private string[] selectedAxis = { "r", "t", "s" };
    private int axisIndex = 0;
    public string axisName = selectedAxis[0];
    private Vector3[] axisList = { new Vector3(0, 1, 0), new Vector3(0, 1, 1), new Vector3(1, 1, 1) };
    //public Renderer = rendering;
    public bool canChangeAxis = true;
    private Quaternion previousRotation;
    private List<string> actions = new List<string>();


    void Start()
    {

    }

    void Update()
    {
        //Change the axis depending on which button you press
        if (Input.GetKeyDown("w"))
        {
            if (canChangeAxis == true)
            {
                axisIndex = (axisIndex + 1) % 3;
                axisName = selectedAxis[axisIndex];
                axis = axisList[axisIndex];
            }

        }

        if (Input.GetKeyDown("q"))
        {
            if (canChangeAxis == true)
            {
                axisIndex = (axisIndex + 2) % 3;
                axisName = selectedAxis[axisIndex];
                axis = axisList[axisIndex];
            }

        }

        /*if (Input.GetKeyDown("r"))
		{
			if (canChangeAxis == true)
			{
				axis = new Vector3(0, 1, 0);
				axisName = "r";
				
			}
		}

		if (Input.GetKeyDown("t"))
		{
			if (canChangeAxis == true)
			{
				axis = new Vector3(0, 1, 1);
				axisName = "t";
				
			}
		}

		if (Input.GetKeyDown("s"))
		{
			if (canChangeAxis == true)
			{
				axis = new Vector3(1, 1, 1);
				axisName = "s";
				Debug.Log("s");
			}
		}*/
    }


    void OnMouseDown()
    {
        //Save our current rotation to recognize what rotation we eventualy did
        if (canChangeAxis == true)
        {
            previousRotation = transform.rotation;
        }

    }

    //Rotate the object with the mouse
    void OnMouseDrag()
    {
        canChangeAxis = false;
        float XaxisRotation = -Input.GetAxis("Mouse X") * rotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.RotateAround(axis, XaxisRotation);

    }


    void OnMouseUp()
    {
        //Magnetize to a symmetry if we are close enough and check what rotation we did
        Quaternion closest = ClosestRotation(allRotations);
        //StartCoroutine(PerformRotation(closest));

        if (Quaternion.Angle(transform.rotation, closest) < 20)
        {
            StartCoroutine(PerformRotation(closest));
            string test = AddRotations(previousRotation, closest);
            Debug.Log(test);
            previousRotation = transform.rotation;
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
    string AddRotations(Quaternion start, Quaternion end)
    {
        string result = "";

        if (axisIndex == 0)
        {
            float angle = (((end.eulerAngles.y + 360) % 360) - ((start.eulerAngles.y + 360) % 360) + 360) % 360;
            for (float i = 0f; i < angle / 90; i++)
            {
                actions.Add("r");
            }

        }

        if (axisIndex == 1)
        {
            if (start != end)
                actions.Add("t");

        }


        if (axisIndex == 2)
        {
            int amount = 0;

            for (int k = 0; k < 3; k++)
            {
                if (end == start * (Quaternion.AngleAxis(120 * k, new Vector3(1, 1, 1))))
                    break;
                amount++;
            }

            for (int j = 0; j < amount; j++)
                actions.Add("s");
        }
        for (int k = actions.Count - 1; k >= 0; k--)
            result += actions[k];

        return result;
    }
}