using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRotate : MonoBehaviour
{

    public float rotationSpeed = 0.2f;




    void start()
    {

    }

    void update()
    {
    }

    //Rotate the object with the mouse
    void OnMouseDrag()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        //select the axis by which you want to rotate the GameObject
        transform.RotateAround(Vector3.down, XaxisRotation);
        transform.RotateAround(Vector3.right, YaxisRotation);

    }

}  