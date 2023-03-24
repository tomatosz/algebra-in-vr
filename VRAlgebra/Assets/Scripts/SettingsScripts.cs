using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScripts : MonoBehaviour
{
    public bool LabelVisibility;
  
    public void ToggleLabels()
    {
        LabelVisibility = !LabelVisibility;
        PlayerPrefs.SetInt("LabelVis", LabelVisibility ? 1 : 0);
    }

}
