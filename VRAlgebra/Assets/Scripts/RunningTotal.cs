using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunningTotal : MonoBehaviour
{
    public TextMeshProUGUI RunningTotalText;

    // Update is called once per frame
    void Update()
    {
        string result = "";
        if (ChooseAxis.actions.Count > 0)
        {
            for (int k = ChooseAxis.actions.Count - 1; k >= 0; k--)
                result += ChooseAxis.actions[k];
        }

        RunningTotalText.text = result;
    }
}
