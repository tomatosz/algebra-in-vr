using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScripts : MonoBehaviour
{
    public bool LabelVisibility = true;
    public Toggle Labels;
  
    public void ToggleLabels()
    {
        LabelVisibility = !LabelVisibility;
        PlayerPrefs.SetInt("LabelVis", Labels.isOn ? 1 : 0);
    }

}
