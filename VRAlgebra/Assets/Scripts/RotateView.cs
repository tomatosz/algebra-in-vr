using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateView : MonoBehaviour
{

    // Script to always make labels face the player (camera)
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
