using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
public class Tetrahedron : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    public Rotate2 cube;
    

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateTetrahedron();
        Updatemesh();
        if (cube.Tetraok == true)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
            this.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void Update()
    {
        
        if (cube.Tetraok == true)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
            this.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void CreateTetrahedron()
    {
        Vector3 p0 = new Vector3(1, 1, 1);
        Vector3 p1 = new Vector3(-1, 1, -1);
        Vector3 p2 = new Vector3(1, -1, -1);
        Vector3 p3 = new Vector3(-1, -1, 1);

        vertices = new Vector3[]
        {
            p0,
            p1,
            p2,
            p3
        };

        triangles = new int[]{
            0,2,1,
            0,1,3,
            0,3,2,
            1,2,3
            
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

