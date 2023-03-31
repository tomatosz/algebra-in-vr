using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunningTotal : MonoBehaviour
{
    public GameObject FixedRotationObject;
    public TextMeshProUGUI RunningTotalText;

    // Update is called once per frame
    void Update()
    {
        RunningTotalText.text = "Here be rotations";   
    }
}
