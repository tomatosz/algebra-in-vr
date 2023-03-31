using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunningTotal2 : MonoBehaviour
{
    public TextMeshProUGUI RunningTotalText;

    // Update is called once per frame
    void Update()
    {
        RunningTotalText.text = string.Join("",ChooseAxis2.actions2);
    }
}
