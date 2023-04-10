using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetupScene : MonoBehaviour
    
{

    public static bool RotateToggle;
    public Toggle RunningTotal;
    public Toggle Labels;
    public TMP_Dropdown RotationMode;
    public static GameObject[] freerotation;
    public static GameObject[] fixedrotation;
    public static GameObject[] rotationtracker;

    // Setup at the start of the scene
    void Start()
    {
        transform.position = new Vector3 (PlayerPrefs.GetFloat("PlayerPosx"), PlayerPrefs.GetFloat("PlayerPosy"), PlayerPrefs.GetFloat("PlayerPosz"));   // set player position and rotation to match previous scene
        transform.eulerAngles = new Vector3 (PlayerPrefs.GetFloat("PlayerRotx"), PlayerPrefs.GetFloat("PlayerRoty"), PlayerPrefs.GetFloat("PlayerRotz"));
       
        
        RotateToggle = true;                                            // Start scene with interactive object
        
        Labels.isOn = PlayerPrefs.GetInt("LabelVis") == 1;              // Set settings toggles to match previously selected settings
        RunningTotal.isOn = PlayerPrefs.GetInt("RunningTotal") == 1;
        
       
        PlayerPrefs.SetInt("RotationMode", 0);                          // Set object to free rotation mode
        RotationMode.value = 0;
        
        
        
        freerotation = GameObject.FindGameObjectsWithTag("FreeRotation");           // Create lists of objects for free rotation, fixed rotation, and the text on pedestals
        fixedrotation = GameObject.FindGameObjectsWithTag("FixedRotation");
        rotationtracker = GameObject.FindGameObjectsWithTag("RotationTracker");
        
        
        
        foreach (GameObject freerot in SetupScene.freerotation)         // Enable free rotation objects
            freerot.SetActive(true);

        foreach (GameObject fixedrot in SetupScene.fixedrotation)       // Disable fixed rotation objects
            fixedrot.SetActive(false);

        foreach (GameObject trackrot in SetupScene.rotationtracker)     // Disable text on pedestals
            trackrot.SetActive(false);
    }

}
