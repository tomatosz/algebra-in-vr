using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class SetupGame : MonoBehaviour
{

    public Toggle RunningTotal;
    public Toggle Labels;

    // Setup at the start of the game
    void Start()
    {
        PlayerPrefs.SetFloat("PlayerPosx", 0);     // save default player position
        PlayerPrefs.SetFloat("PlayerPosy", 0);
        PlayerPrefs.SetFloat("PlayerPosz", -7);
        PlayerPrefs.SetFloat("PlayerRotx", 0);     // save default player rotation
        PlayerPrefs.SetFloat("PlayerRoty", 0);
        PlayerPrefs.SetFloat("PlayerRotz", 0);


        transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerPosx"), PlayerPrefs.GetFloat("PlayerPosy"), PlayerPrefs.GetFloat("PlayerPosz"));  // set player position and rotation to match default settings
        transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("PlayerRotx"), PlayerPrefs.GetFloat("PlayerRoty"), PlayerPrefs.GetFloat("PlayerRotz"));
        
        
        PlayerPrefs.SetInt("RunningTotal", 0);     // save default settings
        PlayerPrefs.SetInt("LabelVis", 0);
        PlayerPrefs.SetInt("RotationMode", 0);
       
        
        Labels.isOn = PlayerPrefs.GetInt("LabelVis") == 1;              // set settings toggles to match default settings
        RunningTotal.isOn = PlayerPrefs.GetInt("RunningTotal") == 1;
    }

}
