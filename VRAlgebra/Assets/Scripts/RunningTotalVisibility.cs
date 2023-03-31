using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunningTotalVisibility : MonoBehaviour
{

    public GameObject RunningTotal;
    public bool RunningTotalVisib;
    public TMP_Dropdown RotationMode;

    // Update is called once per frame
    void Update()
    {
        RunningTotalVisib = PlayerPrefs.GetInt("RunningTotal") == 1 && RotationMode.value == 1;
        RunningTotal.SetActive(RunningTotalVisib);
    }
}
