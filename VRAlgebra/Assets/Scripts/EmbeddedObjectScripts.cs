using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmbeddedObjectScripts : MonoBehaviour
{
    public void CallTetraInCube()
    {
        SceneManager.LoadScene("Cube with Tetraeder");
    }

    public void CallOctaInCube()
    {
        SceneManager.LoadScene("Cube with Octahedron");
    }
}
