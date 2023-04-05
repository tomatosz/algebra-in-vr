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
        string result = "";
        if (ChooseAxis2.actions2.Count > 0)
        {
            for (int k = ChooseAxis2.actions2.Count - 1; k >= 0; k--)
                result += ChooseAxis2.actions2[k];
        }

        RunningTotalText.text = result;
    }
}
