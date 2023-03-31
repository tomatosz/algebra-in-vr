using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScripts : MonoBehaviour
{
    public bool LabelVisibility = true;
    public Toggle Labels;
    public Toggle RunningTotal;
    public GameObject FreeRotationObject;
    public GameObject FixedRotationObject;
    public GameObject FixedRotationAxis;
    public GameObject RotationTracker;
    public TMP_Dropdown RotationMode;

    
    public void ToggleLabels()
    {
        LabelVisibility = !LabelVisibility;
        PlayerPrefs.SetInt("LabelVis", Labels.isOn ? 1 : 0);
    }

    public void ToggleRunningTotal()
    {
        PlayerPrefs.SetInt("RunningTotal", RunningTotal.isOn ? 1 : 0);
    }

    public void ToggleRotationMode()
    {
        if (RotationMode.value == 0)
        {
            FreeRotationObject.SetActive(true);
            FixedRotationObject.SetActive(false);
            FixedRotationAxis.SetActive(false);
            RotationTracker.SetActive(false);
        }
        else if (RotationMode.value == 1)
        {
            FreeRotationObject.SetActive(false);
            FixedRotationObject.SetActive(true);
            FixedRotationAxis.SetActive(true);
            RotationTracker.SetActive(RunningTotal.isOn);
        }
       
    }

}
