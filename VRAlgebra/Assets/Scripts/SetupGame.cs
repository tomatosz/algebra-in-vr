using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupGame : MonoBehaviour
{

    public Toggle RunningTotal;
    public Toggle Labels;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("CamPosx", 0);
        PlayerPrefs.SetFloat("CamPosy", 5);
        PlayerPrefs.SetFloat("CamPosz", -7);
        PlayerPrefs.SetFloat("CamRotx", 0);
        PlayerPrefs.SetFloat("CamRoty", 0);
        PlayerPrefs.SetFloat("CamRotz", 0);
        PlayerPrefs.SetInt("RunningTotal", 0);
        PlayerPrefs.SetInt("LabelVis", 0);
        PlayerPrefs.SetInt("RotationMode", 0);
        Labels.isOn = PlayerPrefs.GetInt("LabelVis") == 1;
        RunningTotal.isOn = PlayerPrefs.GetInt("RunningTotal") == 1;
    }

}
