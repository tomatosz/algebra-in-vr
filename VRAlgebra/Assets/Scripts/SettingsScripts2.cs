using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScripts2 : MonoBehaviour
{
    public bool LabelVisibility = true;
    public Toggle Labels;
    public Toggle RunningTotal;
    public GameObject FreeRotationObject1;
    public GameObject FixedRotationObject1;
    public GameObject FixedRotationAxis1;
    public GameObject RotationTracker1;
    public GameObject FreeRotationObject2;
    public GameObject FixedRotationObject2;
    public GameObject FixedRotationAxis2;
    public GameObject RotationTracker2;
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
            FreeRotationObject1.SetActive(true);
            FixedRotationObject1.SetActive(false);
            FixedRotationAxis1.SetActive(false);
            RotationTracker1.SetActive(false);
            FreeRotationObject2.SetActive(true);
            FixedRotationObject2.SetActive(false);
            FixedRotationAxis2.SetActive(false);
            RotationTracker2.SetActive(false);
        }
        else if (RotationMode.value == 1)
        {
            FreeRotationObject1.SetActive(false);
            FixedRotationObject1.SetActive(true);
            FixedRotationAxis1.SetActive(true);
            RotationTracker1.SetActive(RunningTotal.isOn);
            FreeRotationObject2.SetActive(false);
            FixedRotationObject2.SetActive(true);
            FixedRotationAxis2.SetActive(true);
            RotationTracker2.SetActive(RunningTotal.isOn);
        }

    }
}
