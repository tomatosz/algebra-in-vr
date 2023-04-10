using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunningTotal : MonoBehaviour
{
    public TextMeshProUGUI RunningTotalText;

    // Script to display the running total of actions on the pedestal. Identical to RunningTotal2.cs, except this takes its running total from ChooseAxis.cs instead of ChooseAxis2.cs
    void Update()
    {
        string result = "";
        if (ChooseAxis.actions.Count > 0)
        {
            // Create a string from the list ChooseAxis.actions, but inverted by iteratively adding the last element of the list to the string
            for (int k = ChooseAxis.actions.Count - 1; k >= 0; k--)
                result += ChooseAxis.actions[k]; 
        }

        RunningTotalText.text = result; // Display the string on the pedestal
    }
}
