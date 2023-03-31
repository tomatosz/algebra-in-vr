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

    public GameObject kubus;
    public Material groen;
    public Material rood;
    public Material wit;



    //vertices
    //cube
    private Vector3 p0;
    private Vector3 p1;
    private Vector3 p2;
    private Vector3 p3;
    private Vector3 p4;
    private Vector3 p5;
    private Vector3 p6;
    private Vector3 p7;
    //other
    private Vector3 p8;
    private Vector3 p9;
    private Vector3 p10;
    private Vector3 p11;
    private Vector3 p12;
    private Vector3 p13;
    private Vector3 p14;
    private Vector3 p15;
    private Vector3 p16;
    private Vector3 p17;
    private Vector3 p18;
    private Vector3 p19;
    //mids
    private Vector3 m20;
    private Vector3 m21;
    private Vector3 m22;
    private Vector3 m23;
    private Vector3 m24;
    private Vector3 m25;
    private Vector3 m26;
    private Vector3 m27;
    private Vector3 m28;
    private Vector3 m29;
    private Vector3 m30;
    private Vector3 m31;



    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateDodecahedron();

        Updatemesh();


    }

    void Update()
    {

        if (kubus.GetComponent<DodecahedronRotateIso>().goodrotation == 0)
            this.GetComponent<Renderer>().material = wit;
        else if (kubus.GetComponent<DodecahedronRotateIso>().goodrotation == 1)
            this.GetComponent<Renderer>().material = groen;
        else if (kubus.GetComponent<DodecahedronRotateIso>().goodrotation == 2)
            this.GetComponent<Renderer>().material = rood;
    }

    void CreateDodecahedron()
    {
        double h = 2 / (1 + Math.Sqrt(5));
        float a = (float)(1 + h);
        float b = (float)(1 - (h * h));
        //cube
        p0 = new Vector3(1, 1, 1);
        p1 = new Vector3(1, 1, -1);
        p2 = new Vector3(1, -1, 1);
        p3 = new Vector3(1, -1, -1);
        p4 = new Vector3(-1, 1, 1);
        p5 = new Vector3(-1, 1, -1);
        p6 = new Vector3(-1, -1, 1);
        p7 = new Vector3(-1, -1, -1);
        //other
        p8 = new Vector3(0, a, b);
        p9 = new Vector3(0, a, -b);
        p10 = new Vector3(0, -a, b);
        p11 = new Vector3(0, -a, -b);
        p12 = new Vector3(a, b, 0);
        p13 = new Vector3(a, -b, 0);
        p14 = new Vector3(-a, b, 0);
        p15 = new Vector3(-a, -b, 0);
        p16 = new Vector3(b, 0, a);
        p17 = new Vector3(-b, 0, a);
        p18 = new Vector3(b, 0, -a);
        p19 = new Vector3(-b, 0, -a);
        //middles of planes
        m20 = 0.2f * (p0 + p16 + p17 + p4 + p8);
        m21 = 0.2f * (p0 + p8 + p9 + p1 + p12);
        m22 = 0.2f * (p0 + p12 + p13 + p2 + p16);
        m23 = 0.2f * (p12 + p1 + p18 + p3 + p13);
        m24 = 0.2f * (p3 + p11 + p10 + p2 + p13);
        m25 = 0.2f * (p6 + p17 + p16 + p2 + p10);
        m26 = 0.2f * (p1 + p9 + p5 + p19 + p18);
        m27 = 0.2f * (p5 + p9 + p8 + p4 + p14);
        m28 = 0.2f * (p5 + p14 + p15 + p7 + p19);
        m29 = 0.2f * (p7 + p11 + p3 + p18 + p19);
        m30 = 0.2f * (p6 + p10 + p11 + p7 + p15);
        m31 = 0.2f * (p6 + p15 + p14 + p4 + p17);



        vertices = new Vector3[]
        {
            p0,p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15,p16,p17,p18,p19,m20,m21,m22,m23,m24,m25,m26,m27,m28,m29,m30,m31
        };

        triangles = new int[]{
            //12 times 5 triangles
            //plane 1 (round p0-p16-p17-p4-p8) m20
            0,20,16,
            16,20,17,
            17,20,4,
            4,20,8,
            8,20,0,
            //plane 2 (round p0-p8-p9-p1-p12) m21
            0,21,8,
            8,21,9,
            9,21,1,
            1,21,12,
            12,21,0,
            //plane 3 (round p0-p12-p13-p2-p16) m22
            0,22,12,
            12,22,13,
            13,22,2,
            2,22,16,
            16,22,0,
            //plane 4 (round p12-p1-p18-p3-p13) m23
            12,23,1,
            1,23,18,
            18,23,3,
            3,23,13,
            13,23,12,
            //plane 5 (round p3-p11-p10-p2-p13) m24
            3,24,11,
            11,24,10,
            10,24,2,
            2,24,13,
            13,24,3,
            //plane 6 (round p6-p17-p16-p2-p10) m25
            6,25,17,
            17,25,16,
            16,25,2,
            2,25,10,
            10,25,6,
            //plane 7 (round p1-p9-p5-p19-p18) m26
            1,26,9,
            9,26,5,
            5,26,19,
            19,26,18,
            18,26,1,
            //plane 8 (round p5-p9-p8-p4-p14) m27
            5,27,9,
            9,27,8,
            8,27,4,
            4,27,14,
            14,27,5,
            //plane 9 (round p5-p14-p15-p7-p19) m28
            5,28,14,
            14,28,15,
            15,28,7,
            7,28,19,
            19,28,5,
            //plane 10 (round p7-p11-p3-p18-p19) m29
            7,29,11,
            11,29,3,
            3,29,18,
            18,29,19,
            19,29,7,
            //plane 11 (round p6-p10-p11-p7-p15) m30
            6,30,10,
            10,30,11,
            11,30,7,
            7,30,15,
            15,30,6,
            //plane 12 (round p6-p15-p14-p4-p17) m31
            6,31,15,
            15,31,14,
            14,31,4,
            4,31,17,
            17,31,6
        };
    }

    void Updatemesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.Optimize();
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

    }
    //Rotate the object with the mouse

}