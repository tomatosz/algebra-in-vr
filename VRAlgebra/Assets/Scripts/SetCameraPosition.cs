using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraPosition : MonoBehaviour

    
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3 (PlayerPrefs.GetFloat("CamPosx"), PlayerPrefs.GetFloat("CamPosy"), PlayerPrefs.GetFloat("CamPosz"));
        transform.eulerAngles = new Vector3 (PlayerPrefs.GetFloat("CamRotx"), PlayerPrefs.GetFloat("CamRoty"), PlayerPrefs.GetFloat("CamRotz"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
