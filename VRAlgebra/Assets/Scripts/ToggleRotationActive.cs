using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRotationActive : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        GetComponent<BoxCollider>().enabled = SetupScene.RotateToggle;
    }
}
