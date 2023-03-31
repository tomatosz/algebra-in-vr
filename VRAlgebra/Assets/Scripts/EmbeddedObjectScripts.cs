using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmbeddedObjectScripts : MonoBehaviour
{
    public void CallTetraInCube()
    {
        PlayerPrefs.SetFloat("CamPosx", Camera.main.transform.position.x);
        PlayerPrefs.SetFloat("CamPosy", Camera.main.transform.position.y);
        PlayerPrefs.SetFloat("CamPosz", Camera.main.transform.position.z);
        PlayerPrefs.SetFloat("CamRotx", Camera.main.transform.rotation.eulerAngles.x);
        PlayerPrefs.SetFloat("CamRoty", Camera.main.transform.rotation.eulerAngles.y);
        PlayerPrefs.SetFloat("CamRotz", Camera.main.transform.rotation.eulerAngles.z);
        SceneManager.LoadScene("Cube with Tetraeder");
    }

    public void CallOctaInCube()
    {
        PlayerPrefs.SetFloat("CamPosx", Camera.main.transform.position.x);
        PlayerPrefs.SetFloat("CamPosy", Camera.main.transform.position.y);
        PlayerPrefs.SetFloat("CamPosz", Camera.main.transform.position.z);
        PlayerPrefs.SetFloat("CamRotx", Camera.main.transform.rotation.eulerAngles.x);
        PlayerPrefs.SetFloat("CamRoty", Camera.main.transform.rotation.eulerAngles.y);
        PlayerPrefs.SetFloat("CamRotz", Camera.main.transform.rotation.eulerAngles.z);
        SceneManager.LoadScene("Cube with Octahedron");
    }
}
