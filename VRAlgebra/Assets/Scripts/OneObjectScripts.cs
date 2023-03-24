using UnityEngine;
using UnityEngine.SceneManagement;

public class OneObjectScripts : MonoBehaviour
{
    public GameObject RotationObject;

    public void CallOneObjectCube()
    {
        SceneManager.LoadScene("OneObjectCube");
       
    }

}
