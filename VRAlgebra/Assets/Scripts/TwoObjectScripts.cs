using UnityEngine;
using UnityEngine.SceneManagement;

public class TwoObjectScripts : MonoBehaviour
{
    public void CallTwoObjectCube()
    {
        PlayerPrefs.SetFloat("CamPosx", Camera.main.transform.position.x);
        PlayerPrefs.SetFloat("CamPosy", Camera.main.transform.position.y);
        PlayerPrefs.SetFloat("CamPosz", Camera.main.transform.position.z);
        PlayerPrefs.SetFloat("CamRotx", Camera.main.transform.rotation.eulerAngles.x);
        PlayerPrefs.SetFloat("CamRoty", Camera.main.transform.rotation.eulerAngles.y);
        PlayerPrefs.SetFloat("CamRotz", Camera.main.transform.rotation.eulerAngles.z);
        SceneManager.LoadScene("TwoObjectCube");
    }

}
