using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetupSceneNoFeedback: MonoBehaviour
    
{

    public Toggle RunningTotal;
    public Toggle Labels;
    public TMP_Dropdown RotationMode;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3 (PlayerPrefs.GetFloat("CamPosx"), PlayerPrefs.GetFloat("CamPosy"), PlayerPrefs.GetFloat("CamPosz"));
        transform.eulerAngles = new Vector3 (PlayerPrefs.GetFloat("CamRotx"), PlayerPrefs.GetFloat("CamRoty"), PlayerPrefs.GetFloat("CamRotz"));
        SetupScene.RotateToggle = true;
        Labels.isOn = PlayerPrefs.GetInt("LabelVis") == 1;
        RunningTotal.isOn = PlayerPrefs.GetInt("RunningTotal") == 1;
        PlayerPrefs.SetInt("RotationMode", 0);
        RotationMode.value = 0;
    }

}
