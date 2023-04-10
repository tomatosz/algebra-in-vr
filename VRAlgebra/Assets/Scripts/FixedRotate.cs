using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class FixedRotate : MonoBehaviour
{

	//public float rotationSpeed = 0.2f;
	public List<string> actions = new List<string>();
	public int x = 0;
	public int y = 0;
	public int z = 0;
	public Quaternion rotation = Quaternion.Euler(0,0,0);

	//public Renderer = rendering;


	void Update()
	{
        if (Input.GetKeyDown("r"))
        {
			y =(y+90) %360;
			rotation = Quaternion.AngleAxis(90, new Vector3(1, 0, 0));
			StartCoroutine(PerformRotation(rotation));
			actions.Add("r");

			PrintActions(actions);

		}

		if (Input.GetKeyDown("t"))
		{
			x =(x +90) % 360;
			z =(z - 90) % 360;
			rotation = Quaternion.Euler(x, y, z);
			StartCoroutine(PerformRotation(rotation));
			actions.Add("t");
			PrintActions(actions);
		}

		if (Input.GetKeyDown("s"))
		{
			y = (y - 180) % 360;
			z = (z + 90) % 360;
			rotation = Quaternion.Euler(x, y, z);
			StartCoroutine(PerformRotation(rotation));
			actions.Add("s");
			PrintActions(actions);
		}
	}

	//Perform the rotation to a target rotation
	IEnumerator PerformRotation(Quaternion targetRotation)
	{
		this.GetComponent<Renderer>().material.color = Color.red;
		float progress = 0f;
		float speed = 0.3f;

		while (progress < 1f)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, progress);
			progress += Time.deltaTime * speed;

			if (progress < 1f)
			{
				yield return null;
			}
		}
		this.GetComponent<Renderer>().material.color = Color.white;
	}
	

	public void PrintActions(List<string> input)
    {
		string res = "";
		for (int i = input.Count - 1; i >= 0; i--)
			res += input[i];
		Debug.Log(res);
	}
}

