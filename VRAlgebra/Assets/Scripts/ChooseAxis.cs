using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAxis : MonoBehaviour
{
	public float rotationSpeed = 0.2f;
	static public Quaternion[] allRotations = GenerateRotationsCube();
	public Vector3 axis = new Vector3(0, 1, 0);
	public string axisName = "r";
	//public Renderer = rendering;
	public bool canChangeAxis = true;

	void Start()
	{

	}

	void Update()
	{
		if (Input.GetKeyDown("r"))
		{
			if (canChangeAxis == true)
			{
				axis = new Vector3(0, 1, 0);
				axisName = "r";
				Debug.Log("r");
			}
		}

		if (Input.GetKeyDown("t"))
		{
			if (canChangeAxis == true)
			{
				axis = new Vector3(0, 1, 1);
				axisName = "t";
				Debug.Log("t");
			}
		}

		if (Input.GetKeyDown("s"))
		{
			if (canChangeAxis == true)
			{
				axis = new Vector3(1, 1, 1);
				axisName = "s";
				Debug.Log("s");
			}
		}
	}



	//Rotate the object with the mouse
	void OnMouseDrag()
	{
		canChangeAxis = false;
		float XaxisRotation = -Input.GetAxis("Mouse X") * rotationSpeed;
		float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
		//select the axis by which you want to rotate the GameObject
		transform.RotateAround(axis, XaxisRotation);

	}

	//Go back to original state
	void OnMouseUp()
	{
		Quaternion closest = ClosestRotation(allRotations);
		//StartCoroutine(PerformRotation(closest));

		if (Quaternion.Angle(transform.rotation, closest) < 20)
		{
			StartCoroutine(PerformRotation(closest));
			canChangeAxis = true;
		}
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


	//Generate all rotations for the cube/octahedron
	static Quaternion[] GenerateRotationsCube()
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
			allRotations[i + 13] = Quaternion.AngleAxis(180, new Vector3(((i + 2) % 3 - 1) * ((i + 2) % 3 - 1), ((i + 1) % 3 - 1) * ((i + 1) % 3 - 1), (i % 3 - 1) * (i % 3 - 1)));
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
		Quaternion closest = rotations[0];
		for (int i = 1; i < rotations.Length; i++)
		{
			if (Quaternion.Angle(transform.rotation, rotations[i]) < Quaternion.Angle(transform.rotation, closest))
				closest = rotations[i];
		}
		return closest;
	}
}