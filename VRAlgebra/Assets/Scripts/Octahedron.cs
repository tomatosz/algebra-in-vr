using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
public class Octahedron : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    public GameObject kubus;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateOctahedron();
        Updatemesh();
    }

    void Update()
    {
        this.GetComponent<MeshRenderer>().material = kubus.GetComponent<MeshRenderer>().material;
    }

    void CreateOctahedron()
    {
        Vector3 p0 = new Vector3(0, 0, 1);
        Vector3 p1 = new Vector3(0, 1, 0);
        Vector3 p2 = new Vector3(1, 0, 0);
        Vector3 p3 = new Vector3(0, 0, -1);
        Vector3 p4 = new Vector3(0, -1, 0);
        Vector3 p5 = new Vector3(-1, 0, 0);

        vertices = new Vector3[]
        {
            p0,
            p1, 
            p2, 
            p3, 
            p4, 
            p5
        };

        triangles = new int[]{
            0,2,1,
            0,4,2,
            0,5,4,
            0,1,5,
            3,1,2,
            3,2,4,
            3,4,5,
            3,5,1
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
