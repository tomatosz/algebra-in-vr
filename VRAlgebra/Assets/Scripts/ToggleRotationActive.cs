using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRotationActive : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Keep an object interatible (its boxcollider enabled) when RotateToggle is on, so when there are no menus
        GetComponent<BoxCollider>().enabled = SetupScene.RotateToggle;
    }
}
