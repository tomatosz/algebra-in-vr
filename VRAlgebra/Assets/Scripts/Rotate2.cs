using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Rotate2 : MonoBehaviour
{

    public float rotationSpeed = 0.2f;
    static public Quaternion[] allRotations = GenerateRotations();
    public Material Redtransp;
    public Material Greentransp;
    public Material Transparant;
    public bool Tetraok=true;
    private int[] teraederrotationsindex = { 0, 2, 5, 8, 16, 17, 18, 19, 20, 21, 22, 23 };

    private bool isTriggerPressed =true;


    //Rotate the object with the mouse
    public void OnTriggerDrag()
    {
        isTriggerPressed = true;
        if (isTriggerPressed == true)
        {
            float XaxisRotation = Input.GetAxis("Vertical") * rotationSpeed;
            float YaxisRotation = Input.GetAxis("Horizontal") * rotationSpeed;
            //select the axis by which you want to rotate the GameObject
            transform.RotateAround(Vector3.down, XaxisRotation);
            transform.RotateAround(Vector3.right, YaxisRotation);
            this.GetComponent<MeshRenderer>().material = Transparant;
        }
    }

    //Go back to original state
    public void OnTriggerUp()
    {
        isTriggerPressed = false;
        Quaternion closest = ClosestRotation(allRotations);
        if(Quaternion.Angle(transform.rotation, closest)<20)
        {
            StartCoroutine(PerformRotation(closest));
            this.GetComponent<MeshRenderer>().material = Greentransp;
        }
        else
            this.GetComponent<MeshRenderer>().material = Redtransp;

    }

    //Perform the rotation to a target rotation
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


    //Generate all rotations
    static Quaternion[] GenerateRotations()
    {
        Quaternion[] allRotations = new Quaternion[24];
        //
        for (int i = 0; i <= 3; i++)
            allRotations[i] = Quaternion.AngleAxis(i * 90, new Vector3(0, 1, 0));
        for (int i = 0; i <= 2; i++)
            allRotations[i + 4] = Quaternion.AngleAxis(90 + i * 90, new Vector3(1, 0, 0));
        for (int i = 0; i <= 2; i++)
            allRotations[i + 7] = Quaternion.AngleAxis(90 + i * 90, new Vector3(0, 0, 1));
        //
        for (int i = 0; i <= 2; i++)
            allRotations[i + 10] = Quaternion.AngleAxis(180, new Vector3((i + 1) % 3 - 1, (i + 2) % 3 - 1, i % 3 - 1));
        for (int i = 0; i <= 2; i++)
            allRotations[i + 13] = Quaternion.AngleAxis(180, new Vector3(((i + 2) % 3 - 1)* ((i + 2) % 3 - 1), ((i + 1) % 3 - 1)* ((i + 1) % 3 - 1), (i % 3 - 1)* (i % 3 - 1)));
        //
        for (int i = 0; i <= 1; i += 1)
        {
            allRotations[4 * i + 16] = Quaternion.AngleAxis(120 + 120 * i, new Vector3(-1, -1, 1));
            allRotations[4 * i + 17] = Quaternion.AngleAxis(120 + 120 * i, new Vector3(-1, 1, 1));
            allRotations[4 * i + 18] = Quaternion.AngleAxis(120 + 120 * i, new Vector3(1, -1, 1));
            allRotations[4 * i + 19] = Quaternion.AngleAxis(120 + 120 * i, new Vector3(1, 1, 1));
        }

        return allRotations;
    }

    //Finded the nearest Rotation
    Quaternion ClosestRotation(Quaternion[] rotations)
    {
        int indexclosest=0;
        
        Quaternion closest = rotations[0];
        for (int i = 0; i < rotations.Length; i++)
        {
            if (Quaternion.Angle(transform.rotation, rotations[i]) < Quaternion.Angle(transform.rotation, closest))
            {
                closest = rotations[i];
                indexclosest = i;
            }
        }
        this.Tetraok = false;
        for(int j=0;j<12;j++)
        {
            if (indexclosest == teraederrotationsindex[j])
            {
                this.Tetraok = true;
                
            }
            
        }
        return closest;
    }
}