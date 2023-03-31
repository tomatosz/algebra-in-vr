using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetupScene2 : MonoBehaviour
{
    public Toggle RunningTotal;
    public Toggle Labels;
    public GameObject RotationTracker1;
    public GameObject RotationTracker2;
    public GameObject FixedRotationObject1;
    public GameObject FixedRotationObject2;
    public TMP_Dropdown RotationMode;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat("CamPosx"), PlayerPrefs.GetFloat("CamPosy"), PlayerPrefs.GetFloat("CamPosz"));
        transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("CamRotx"), PlayerPrefs.GetFloat("CamRoty"), PlayerPrefs.GetFloat("CamRotz"));
        SetupScene.RotateToggle = true;
        Labels.isOn = PlayerPrefs.GetInt("LabelVis") == 1;
        RunningTotal.isOn = PlayerPrefs.GetInt("RunningTotal") == 1;
        PlayerPrefs.SetInt("RotationMode", 0);
        RotationMode.value = 0;
        RotationTracker1.SetActive(FixedRotationObject1.activeSelf && RunningTotal.isOn);
        RotationTracker2.SetActive(FixedRotationObject2.activeSelf && RunningTotal.isOn);
    }

}
