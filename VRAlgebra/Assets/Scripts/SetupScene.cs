using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupScene : MonoBehaviour

    
{

    public static bool RotateToggle;
    public Toggle RunningTotal;
    public GameObject RotationTracker;
    public GameObject FixedRotationObject;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3 (PlayerPrefs.GetFloat("CamPosx"), PlayerPrefs.GetFloat("CamPosy"), PlayerPrefs.GetFloat("CamPosz"));
        transform.eulerAngles = new Vector3 (PlayerPrefs.GetFloat("CamRotx"), PlayerPrefs.GetFloat("CamRoty"), PlayerPrefs.GetFloat("CamRotz"));
        RotateToggle = true;
        RotationTracker.SetActive(FixedRotationObject.activeSelf && RunningTotal.isOn);
    }

}
