using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float rotationSpeed = 0.2f;
    static public Quaternion[] allRotations = GenerateRotations();
    public int test = 0;


    void start()
    {

    }

    void update()
    {
    }

    //Rotate the object with the mouse
    void OnMouseDrag()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        //select the axis by which you want to rotate the GameObject
        transform.RotateAround(Vector3.down, XaxisRotation);
        transform.RotateAround(Vector3.right, YaxisRotation);
        this.GetComponent<Renderer>().material.color = Color.white;
    }

    //Go back to original state
    void OnMouseUp()
    {
        Quaternion closest = ClosestRotation(allRotations);
        if(Quaternion.Angle(transform.rotation, closest)<20)
        {
            StartCoroutine(PerformRotation(closest));
            this.GetComponent<Renderer>().material.color = Color.green;
        }
        else
            this.GetComponent<Renderer>().material.color = Color.red;

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


    //Generate all rotations
    static Quaternion[] GenerateRotations()
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
            allRotations[i + 13] = Quaternion.AngleAxis(180, new Vector3((i + 2) % 3 - 1, (i + 1) % 3 - 1, i % 3 - 1));
        //
        for (int i = 0; i <= 1; i += 1)
        {
            allRotations[4 * i + 15] = Quaternion.AngleAxis(120 + 120 * i, new Vector3(-1, -1, 1));
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
        for (int i = 0; i < rotations.Length; i++)
        {
            if (Quaternion.Angle(transform.rotation, rotations[i]) < Quaternion.Angle(transform.rotation, closest))
                closest = rotations[i];
        }
        return closest;
    }
}