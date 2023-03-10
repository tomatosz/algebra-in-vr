using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

	public float rotationSpeed = 0.2f;
	//static public Quaternion nearestState = Quaternion.Euler(0, 0, 0);
	static public Quaternion[] allRotations = new Quaternion[24];


	void start()
	{
		for (int i = 0; i <= 3; i++)
			allRotations[i] = Quaternion.AngleAxis(i * 90, Vector3(0, 1, 0));
		for (int i = 0; i <= 2; i++)
			allRotations[i + 4] = Quaternion.AngleAxis(90 + i * 90, Vector3(1, 0, 0));
		for (int i = 0; i <= 3; i++)
			allRotations[i + 7] = Quaternion.AngleAxis(90 + i * 90, Vector3(0, 0, 1));
		for (int i = 0; i <= 2; i++)
			allRotations[i + 10] = Quaternion.AngleAxis(180, Vector3((i + 1) % 3 - 1, (i - 1) % 3 - 1, i % 3 - 1));
		for (int i = 0; i <= 2; i++)
			allRotations[i + 13] = Quaternion.AngleAxis(180, Vector3((i - 1) % 3 - 1, (i + 1) % 3 - 1, i % 3 - 1));
		for (int i = 0; i <= 1; i += 1)
		{
			allRotations[4 * i + 15] = Quaternion.angleAxis(120 + 120 * i, Vector3(-1, -1, 1));
			allRotations[4 * i + 17] = Quaternion.angleAxis(120 + 120 * i, Vector3(-1, 1, 1));
			allRotations[4 * i + 18] = Quaternion.angleAxis(120 + 120 * i, Vector3(1, -1, 1));
			allRotations[4 * i + 19] = Quaternion.angleAxis(120 + 120 * i, Vector3(1, 1, 1));
		}
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


	//Go back to original state
	void OnMouseUp()
	{
		var angle = Quaternion.Angle(transform.rotation, nearestState);
		StartCoroutine(PerformRotation(ClosestRotation(allRotations)));
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

	static Quaternion ClosestRotation(Quaternion[] rotations)
	{
		Quaternion closest;
		foreach (Quaternion v in rotations)
		{
			if (Quaternion.Angle(transform.rotation, v) < smallest)
				closest = v;
		}

		return closest;
	}
}

