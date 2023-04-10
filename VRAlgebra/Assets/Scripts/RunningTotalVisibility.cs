using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunningTotalVisibility : MonoBehaviour
{

    public GameObject RunningTotal;
    public bool RunningTotalVisib;
    public TMP_Dropdown RotationMode;

    // Enabling running totals precisely when both the running total setting is on and the object is in fixed axis rotation
    void Update()
    {
        RunningTotalVisib = PlayerPrefs.GetInt("RunningTotal") == 1 && RotationMode.value == 1; // Playerprefs store integers, not boolean, so have to convert
        RunningTotal.SetActive(RunningTotalVisib);
    }
}
