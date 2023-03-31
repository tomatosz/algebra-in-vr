using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelVisibility : MonoBehaviour
{
    public GameObject Labels;
    public bool LabelVisib;

    // Update is called once per frame
    void Update()
    {
        LabelVisib = PlayerPrefs.GetInt("LabelVis") == 1;
        Labels.SetActive(LabelVisib);
    }
}
