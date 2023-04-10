using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelVisibility : MonoBehaviour
{
    public GameObject Labels;
    public bool LabelVisib;

    // Enabling labels precisely when the label setting is on
    void Update()
    {
        LabelVisib = PlayerPrefs.GetInt("LabelVis") == 1; // Playerprefs store integers, not boolean, so have to convert
        Labels.SetActive(LabelVisib);
    }
}
