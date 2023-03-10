using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float rotationSpeed = 0.2f;
    static public Quaternion nearestState = Quaternion.Euler(0, 0, 0);
    //public allRotations Quaternion = new Quaternion[24];

    /*void start()
    {
        for (int i = 0; i <= 3; i++)
            allRotations[i] = Quaternion.Euler(i * 90, 0, 0);
        for (int i = 0; i <= 3; i++)
            allRotations[i + 4] = Quaternion.Euler(0, i * 90, 0);
        for (int i = 0; i <= 3; i++)
            allRotations[i + 8] = Quaternion.Euler(0, 0, 90 * i);
    }*/

    void Update()
    {

    }

    //Rotate the object with the mouse
    void OnMouseDrag()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        // select the axis by which you want to rotate the GameObject
        transform.RotateAround(Vector3.down, XaxisRotation);
        transform.RotateAround(Vector3.right, YaxisRotation);
    }


    //Go back to original state
    void OnMouseUp()
    {
        var angle = Quaternion.Angle(transform.rotation, nearestState);
        StartCoroutine(PerformRotation(nearestState));
    }

    IEnumerator PerformRotation(Quaternion targetRotation)
    {
        float progress = 0f;
        float speed = 0.3f;

        while (progress < 1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, progress);
            progress += Time.deltaTime * speed;

            if (progress <= 1f)
            {
                yield return null;
            }
        }
    }



    /*static Quaternion ClosestRotation(Quaternion[] allRotations)
    {
		Quaternion closest;
		foreach(Quaternion v in allRotations)
        {
			if (Quaternion.Angle(transform.rotation, v) < smallest)
				closest = v;
		}
		return closest;
    }*/
}