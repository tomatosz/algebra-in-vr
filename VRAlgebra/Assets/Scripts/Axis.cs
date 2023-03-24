using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(0.007f, 2 * target.transform.localScale.y, 0.007f);
        this.transform.position = target.transform.position;
        this.GetComponent<Renderer>().material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.GetComponent<ChooseAxis>().axisName == "r")
            transform.rotation = Quaternion.Euler(0, 0, 0);
        if (target.GetComponent<ChooseAxis>().axisName == "t")
            transform.rotation = Quaternion.Euler(45, 0, 0);
        if (target.GetComponent<ChooseAxis>().axisName == "s")
            transform.rotation = Quaternion.Euler(45, 0, -35);
    }
}