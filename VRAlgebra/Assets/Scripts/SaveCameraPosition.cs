using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCameraPosition : MonoBehaviour
{
    public void SaveCameraPositionScript ()
    {
        PlayerPrefs.SetFloat("CamPosx", Camera.main.transform.position.x);
        PlayerPrefs.SetFloat("CamPosy", Camera.main.transform.position.y);
        PlayerPrefs.SetFloat("CamPosz", Camera.main.transform.position.z);
        PlayerPrefs.SetFloat("CamRotx", Camera.main.transform.rotation.eulerAngles.x);
        PlayerPrefs.SetFloat("CamRoty", Camera.main.transform.rotation.eulerAngles.y);
        PlayerPrefs.SetFloat("CamRotz", Camera.main.transform.rotation.eulerAngles.z);
    }
}
