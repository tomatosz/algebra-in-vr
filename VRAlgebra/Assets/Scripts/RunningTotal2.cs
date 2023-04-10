using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunningTotal2 : MonoBehaviour
{
    public TextMeshProUGUI RunningTotalText;

    // Script to display the running total of actions on the pedestal. Identical to RunningTotal.cs, except this takes its running total from ChooseAxis2.cs instead of ChooseAxis.cs
    void Update()
    {
        string result = "";
        if (ChooseAxis2.actions2.Count > 0)
        {
            // Create a string from the list ChooseAxis2.actions2, but inverted by iteratively adding the last element of the list to the string
            for (int k = ChooseAxis2.actions2.Count - 1; k >= 0; k--)
                result += ChooseAxis2.actions2[k];
        }

        RunningTotalText.text = result; // Display the string on the pedestal
    }
}
