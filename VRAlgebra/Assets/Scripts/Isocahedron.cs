using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
public class Isocahedron : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public GameObject kubus;
    public Material rood;
    public Material groen;
    public Material wit;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateIsocahedron();
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

    void CreateIsocahedron()
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
            0.2f*(p0+p16+p17+p4+p8),0.2f*(p0+p12+p13+p2+p16),0.2f*(p0+p8+p9+p1+p12),
            0.2f*(p0+p8+p9+p1+p12),0.2f*(p12+p1+p18+p3+p13),0.2f*(p1+p9+p5+p19+p18),
            0.2f*(p0+p12+p13+p2+p16),0.2f*(p6+p17+p16+p2+p10),0.2f*(p3+p11+p10+p2+p13),
            0.2f*(p3+p11+p10+p2+p13),0.2f*(p7+p11+p3+p18+p19),0.2f*(p12+p1+p18+p3+p13),
            0.2f*(p5+p9+p8+p4+p14),0.2f*(p6+p15+p14+p4+p17),0.2f*(p0+p16+p17+p4+p8),
            0.2f*(p5+p9+p8+p4+p14),0.2f*(p1+p9+p5+p19+p18),0.2f*(p5+p14+p15+p7+p19),//5
            0.2f*(p6+p17+p16+p2+p10),0.2f*(p6+p15+p14+p4+p17),0.2f*(p6+p10+p11+p7+p15),//6
            0.2f*(p7+p11+p3+p18+p19),0.2f*(p6+p10+p11+p7+p15),0.2f*(p5+p14+p15+p7+p19),//7
            0.2f*(p5+p9+p8+p4+p14),0.2f*(p0+p16+p17+p4+p8),0.2f*(p0+p8+p9+p1+p12),//8
            0.2f*(p5+p9+p8+p4+p14),0.2f*(p0+p8+p9+p1+p12),0.2f*(p1+p9+p5+p19+p18),//9 
            0.2f*(p3+p11+p10+p2+p13),0.2f*(p6+p17+p16+p2+p10),0.2f*(p6+p10+p11+p7+p15),//10
            0.2f*(p3+p11+p10+p2+p13),0.2f*(p6+p10+p11+p7+p15),0.2f*(p7+p11+p3+p18+p19),//11
            0.2f*(p12+p1+p18+p3+p13),0.2f*(p0+p8+p9+p1+p12),0.2f*(p0+p12+p13+p2+p16),//12 
            0.2f*(p3+p11+p10+p2+p13),0.2f*(p12+p1+p18+p3+p13),0.2f*(p0+p12+p13+p2+p16),//13
            0.2f*(p5+p9+p8+p4+p14),0.2f*(p5+p14+p15+p7+p19),0.2f*(p6+p15+p14+p4+p17),//14 
            0.2f*(p6+p15+p14+p4+p17),0.2f*(p5+p14+p15+p7+p19),0.2f*(p6+p10+p11+p7+p15),//15
            0.2f*(p0+p16+p17+p4+p8),0.2f*(p6+p17+p16+p2+p10),0.2f*(p0+p12+p13+p2+p16),//16 
            0.2f*(p0+p16+p17+p4+p8),0.2f*(p6+p15+p14+p4+p17),0.2f*(p6+p17+p16+p2+p10),//17 
            0.2f*(p7+p11+p3+p18+p19),0.2f*(p1+p9+p5+p19+p18),0.2f*(p12+p1+p18+p3+p13),//18 
            0.2f*(p7+p11+p3+p18+p19),0.2f*(p5+p14+p15+p7+p19),0.2f*(p1+p9+p5+p19+p18)//19 
        };

        triangles = new int[]{
            //20 triangles
            0,1,2,
            3,4,5,
            6,7,8,
            9,10,11,
            12,13,14,
            15,16,17,
            18,19,20,
            21,22,23,
            24,25,26,
            27,28,29,
            30,31,32,
            33,34,35,
            36,37,38,
            39,40,41,
            42,43,44,
            45,46,47,
            48,49,50,
            51,52,53,
            54,55,56,
            57,58,59
            
            //in dodeca:
            //plane 1 (round p0-p16-p17-p4-p8)
            
            //plane 2 (round p0-p8-p9-p1-p12)
            
            //plane 3 (round p0-p12-p13-p2-p16)
            
            //plane 4 (round p12-p1-p18-p3-p13)
            
            //plane 5 (round p3-p11-p10-p2-p13)
            
            //plane 6 (round p6-p17-p16-p2-p10)
            
            //plane 7 (round p1-p9-p5-p19-p18)
            
            //plane 8 (round p5-p9-p8-p4-p14)
            
            //plane 9 (round p5-p14-p15-p7-p19)
            
            //plane 10 (round p7-p11-p3-p18-p19)
            
            //plane 11 (round p6-p10-p11-p7-p15)
            
            //plane 12 (round p6-p15-p14-p4-p17)
            
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
}