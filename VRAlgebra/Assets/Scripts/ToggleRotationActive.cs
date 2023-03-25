using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRotationActive : MonoBehaviour
{

    static public bool Rotation;

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rotate>().enabled = Rotation;
        Debug.Log(gameObject.GetComponent<Rotate>().enabled);
    }
}
