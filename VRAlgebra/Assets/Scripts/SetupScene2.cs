using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupScene2 : MonoBehaviour
{
    public Toggle RunningTotal;
    public GameObject RotationTracker1;
    public GameObject RotationTracker2;
    public GameObject FixedRotationObject1;
    public GameObject FixedRotationObject2;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat("CamPosx"), PlayerPrefs.GetFloat("CamPosy"), PlayerPrefs.GetFloat("CamPosz"));
        transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("CamRotx"), PlayerPrefs.GetFloat("CamRoty"), PlayerPrefs.GetFloat("CamRotz"));
        SetupScene.RotateToggle = true;
        RotationTracker1.SetActive(FixedRotationObject1.activeSelf && RunningTotal.isOn);
        RotationTracker2.SetActive(FixedRotationObject2.activeSelf && RunningTotal.isOn);
    }

}
