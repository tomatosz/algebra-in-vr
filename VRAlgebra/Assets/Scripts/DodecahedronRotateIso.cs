using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
public class DodecahedronRotateIso : MonoBehaviour
{


    public float rotationSpeed = 0.2f;
    public int goodrotation = 0; //0wit 1groen 2rood



    //vertices
    //cube
    private static double h = 2 / (1 + Math.Sqrt(5));
    private static float a = (float)(1 + h);
    private static float b = (float)(1 - (h * h));
    //cube
    private static Vector3 p0 = new Vector3(1, 1, 1);
    private static Vector3 p1 = new Vector3(1, 1, -1);
    private static Vector3 p2 = new Vector3(1, -1, 1);
    private static Vector3 p3 = new Vector3(1, -1, -1);
    private static Vector3 p4 = new Vector3(-1, 1, 1);
    private static Vector3 p5 = new Vector3(-1, 1, -1);
    private static Vector3 p6 = new Vector3(-1, -1, 1);
    private static Vector3 p7 = new Vector3(-1, -1, -1);
    //other
    private static Vector3 p8 = new Vector3(0, a, b);
    private static Vector3 p9 = new Vector3(0, a, -b);
    private static Vector3 p10 = new Vector3(0, -a, b);
    private static Vector3 p11 = new Vector3(0, -a, -b);
    private static Vector3 p12 = new Vector3(a, b, 0);
    private static Vector3 p13 = new Vector3(a, -b, 0);
    private static Vector3 p14 = new Vector3(-a, b, 0);
    private static Vector3 p15 = new Vector3(-a, -b, 0);
    private static Vector3 p16 = new Vector3(b, 0, a);
    private static Vector3 p17 = new Vector3(-b, 0, a);
    private static Vector3 p18 = new Vector3(b, 0, -a);
    private static Vector3 p19 = new Vector3(-b, 0, -a);

    static public Quaternion[] CalcAllRotations = GenerateRotationsDodecahedron();



    //Rotate the object with the mouse
    void OnMouseDrag()
    {
        goodrotation = 0;
        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        //select the axis by which you want to rotate the GameObject
        transform.RotateAround(Vector3.down, XaxisRotation);
        transform.RotateAround(Vector3.right, YaxisRotation);


    }

    //Go back to original state
    void OnMouseUp()
    {
        Quaternion closest = ClosestRotation(CalcAllRotations);
        if (Quaternion.Angle(transform.rotation, closest) < 30)
        {
            goodrotation = 1;
            StartCoroutine(PerformRotation(closest));
        }

        else
        {
            goodrotation = 2;

        }
    }
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

    static Quaternion[] GenerateRotationsDodecahedron()
    {
        Quaternion[] allRotations = new Quaternion[60];
        //rotations over edges
        allRotations[0] = Quaternion.AngleAxis(0, p0);
        allRotations[1] = Quaternion.AngleAxis(180, (p16 + p17));
        allRotations[2] = Quaternion.AngleAxis(180, (p2 + p16));
        allRotations[3] = Quaternion.AngleAxis(180, (p2 + p13));
        allRotations[4] = Quaternion.AngleAxis(180, (p2 + p10));
        allRotations[5] = Quaternion.AngleAxis(180, (p12 + p13));
        allRotations[6] = Quaternion.AngleAxis(180, (p13 + p3));
        allRotations[7] = Quaternion.AngleAxis(180, (p3 + p18));
        allRotations[8] = Quaternion.AngleAxis(180, (p3 + p11));
        allRotations[9] = Quaternion.AngleAxis(180, (p7 + p11));
        allRotations[10] = Quaternion.AngleAxis(180, (p7 + p19));
        allRotations[11] = Quaternion.AngleAxis(180, (p7 + p15));
        allRotations[12] = Quaternion.AngleAxis(180, (p10 + p11));
        allRotations[13] = Quaternion.AngleAxis(180, (p6 + p10));
        allRotations[14] = Quaternion.AngleAxis(180, (p6 + p15));
        allRotations[15] = Quaternion.AngleAxis(180, (p6 + p17));

        //rotations over vertices
        for (int i = 0; i < 2; i++)
        {
            allRotations[16 + i] = Quaternion.AngleAxis(180, p3);
            allRotations[18 + i] = Quaternion.AngleAxis(120 + (i * 120), p11);
            allRotations[20 + i] = Quaternion.AngleAxis(120 + (i * 120), p7);
            allRotations[22 + i] = Quaternion.AngleAxis(120 + (i * 120), p13);
            allRotations[24 + i] = Quaternion.AngleAxis(120 + (i * 120), p2);
            allRotations[26 + i] = Quaternion.AngleAxis(120 + (i * 120), p10);
            allRotations[28 + i] = Quaternion.AngleAxis(120 + (i * 120), p6);
            allRotations[30 + i] = Quaternion.AngleAxis(120 + (i * 120), p15);
            allRotations[32 + i] = Quaternion.AngleAxis(120 + (i * 120), p16);
            allRotations[34 + i] = Quaternion.AngleAxis(120 + (i * 120), p17);
        }

        //rotations over faces
        for (int i = 0; i < 4; i++)
        {
            allRotations[36 + i] = Quaternion.AngleAxis(72 + (i * 72), 0.2f * (p6 + p17 + p16 + p2 + p10));//plane6
            allRotations[40 + i] = Quaternion.AngleAxis(72 + (i * 72), 0.2f * (p0 + p12 + p13 + p2 + p16));//plane 3
            allRotations[44 + i] = Quaternion.AngleAxis(72 + (i * 72), 0.2f * (p3 + p11 + p10 + p2 + p13));//plane 5
            allRotations[48 + i] = Quaternion.AngleAxis(72 + (i * 72), 0.2f * (p12 + p1 + p18 + p3 + p13));//plane 4
            allRotations[52 + i] = Quaternion.AngleAxis(72 + (i * 72), 0.2f * (p7 + p11 + p3 + p18 + p19));//plane 10
            allRotations[56 + i] = Quaternion.AngleAxis(72 + (i * 72), 0.2f * (p6 + p10 + p11 + p7 + p15));//plane 11
        }
        return allRotations;
    }

    Quaternion ClosestRotation(Quaternion[] rotations)
    {
        Quaternion closest = new Quaternion();
        for (int i = 1; i < 60; i++)
        {
            if (Quaternion.Angle(transform.rotation, rotations[i]) < Quaternion.Angle(transform.rotation, closest))
                closest = rotations[i];
        }
        return closest;
    }
}

