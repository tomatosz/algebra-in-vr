using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetupScene : MonoBehaviour
    
{

    public static bool RotateToggle;
    public Toggle RunningTotal;
    public Toggle Labels;
    public TMP_Dropdown RotationMode;
    public static GameObject[] freerotation;
    public static GameObject[] fixedrotation;
    public static GameObject[] rotationtracker;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3 (PlayerPrefs.GetFloat("CamPosx"), PlayerPrefs.GetFloat("CamPosy"), PlayerPrefs.GetFloat("CamPosz"));
        transform.eulerAngles = new Vector3 (PlayerPrefs.GetFloat("CamRotx"), PlayerPrefs.GetFloat("CamRoty"), PlayerPrefs.GetFloat("CamRotz"));
        RotateToggle = true;
        Labels.isOn = PlayerPrefs.GetInt("LabelVis") == 1;
        RunningTotal.isOn = PlayerPrefs.GetInt("RunningTotal") == 1;
        PlayerPrefs.SetInt("RotationMode", 0);
        RotationMode.value = 0;
        freerotation = GameObject.FindGameObjectsWithTag("FreeRotation");
        fixedrotation = GameObject.FindGameObjectsWithTag("FixedRotation");
        rotationtracker = GameObject.FindGameObjectsWithTag("RotationTracker");
        foreach (GameObject freerot in SetupScene.freerotation)
            freerot.SetActive(true);

        foreach (GameObject fixedrot in SetupScene.fixedrotation)
            fixedrot.SetActive(false);

        foreach (GameObject trackrot in SetupScene.rotationtracker)
            trackrot.SetActive(false);
    }

}
