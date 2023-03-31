using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{

    public GameObject target;

    private GameObject tAxis;
    private GameObject sAxis;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject rAxis = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        tAxis = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        sAxis = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        this.transform.localScale = new Vector3(0.007f, 2 * target.transform.localScale.y, 0.007f);
        this.transform.position = target.transform.position;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        tAxis.transform.localScale = new Vector3(0.007f, 2 * target.transform.localScale.y, 0.007f);
        tAxis.transform.position = target.transform.position;
        tAxis.transform.rotation = Quaternion.Euler(45, 0, 0);

        sAxis.transform.localScale = new Vector3(0.007f, 2 * target.transform.localScale.y, 0.007f);
        sAxis.transform.position = target.transform.position;
        sAxis.transform.rotation = Quaternion.Euler(45, 0, -35);
    }

    // Update is called once per frame
    void Update()
    {
        if (target.GetComponent<ChooseAxis>().axisName == "r")
            this.GetComponent<Renderer>().material.color = Color.green;
        else
            this.GetComponent<Renderer>().material.color = Color.black;

        if (target.GetComponent<ChooseAxis>().axisName == "t")
            tAxis.GetComponent<Renderer>().material.color = Color.green;
        else
            tAxis.GetComponent<Renderer>().material.color = Color.black;

        if (target.GetComponent<ChooseAxis>().axisName == "s")
            sAxis.GetComponent<Renderer>().material.color = Color.green;
        else
            sAxis.GetComponent<Renderer>().material.color = Color.black;
    }
}