using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
public class Dodecahedron : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;



    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateDodecahedron();
        Updatemesh();

    }

    void Update()
    {


    }

    void CreateDodecahedron()
    {
        double h = 2 / (1 + Math.Sqrt(5));
        float a = (float)(1 + h);
        float b = (float)(1 - (h * h));
        //cube
        Vector3 p0 = new Vector3(1, 1, 1);
        Vector3 p1 = new Vector3(1, 1, -1);
        Vector3 p2 = new Vector3(1, -1, 1);
        Vector3 p3 = new Vector3(1, -1, -1);
        Vector3 p4 = new Vector3(-1, 1, 1);
        Vector3 p5 = new Vector3(-1, 1, -1);
        Vector3 p6 = new Vector3(-1, -1, 1);
        Vector3 p7 = new Vector3(-1, -1, -1);
        //other
        Vector3 p8 = new Vector3(0, a, b);
        Vector3 p9 = new Vector3(0, a, -b);
        Vector3 p10 = new Vector3(0, -a, b);
        Vector3 p11 = new Vector3(0, -a, -b);
        Vector3 p12 = new Vector3(a, b, 0);
        Vector3 p13 = new Vector3(a, -b, 0);
        Vector3 p14 = new Vector3(-a, b, 0);
        Vector3 p15 = new Vector3(-a, -b, 0);
        Vector3 p16 = new Vector3(b, 0, a);
        Vector3 p17 = new Vector3(-b, 0, a);
        Vector3 p18 = new Vector3(b, 0, -a);
        Vector3 p19 = new Vector3(-b, 0, -a);

        vertices = new Vector3[]
        {
            p0,p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16,p17,p18,p19
        };

        triangles = new int[]{
            //12 times 5 triangles
            //plane 1 (round p0-p16-p17-p4-p8)
            0,4,16,
            16,8,17,
            17,0,4,
            4,16,8,
            8,17,0,
            //plane 2 (round p0-p8-p9-p1-p12)
            0,1,8,
            8,12,9,
            9,0,1,
            1,8,12,
            12,9,0,
            //plane 3 (round p0-p12-p13-p2-p16)
            0,2,12,
            12,16,13,
            13,0,2,
            2,12,16,
            16,13,0,
            //plane 4 (round p12-p1-p18-p3-p13)
            12,3,1,
            1,13,18,
            18,12,3,
            3,1,13,
            13,18,12,
            //plane 5 (round p3-p11-p10-p2-p13)
            3,2,11,
            11,13,10,
            10,3,2,
            2,11,13,
            13,10,3,
            //plane 6 (round p6-p17-p16-p2-p10)
            6,2,17,
            17,10,16,
            16,6,2,
            2,17,10,
            10,16,6,
            //plane 7 (round p1-p9-p5-p19-p18)
            1,19,9,
            9,18,5,
            5,1,19,
            19,9,18,
            18,5,1,
            //plane 8 (round p5-p9-p8-p4-p14)
            5,4,9,
            9,14,8,
            8,5,4,
            4,9,14,
            14,8,5,
            //plane 9 (round p5-p14-p15-p7-p19)
            5,7,14,
            14,19,15,
            15,5,7,
            7,14,19,
            19,15,5,
            //plane 10 (round p7-p11-p3-p18-p19)
            7,18,11,
            11,19,3,
            3,7,18,
            18,11,19,
            19,3,7,
            //plane 11 (round p6-p10-p11-p7-p15)
            6,7,10,
            10,15,11,
            11,6,7,
            7,10,15,
            15,11,6,
            //plane 12 (round p6-p15-p14-p4-p17)
            6,4,15,
            15,17,14,
            14,6,4,
            4,15,17,
            17,14,6
        };
    }

    void Updatemesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.Optimize();
        mesh.RecalculateNormals();

    }
}
