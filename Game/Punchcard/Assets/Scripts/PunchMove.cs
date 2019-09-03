using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchMove : MonoBehaviour
{
	[Range(-5, 5)]
	public float speed = -3f;

	void Update()
	{
		transform.position += new Vector3(0, speed * Time.deltaTime, 0);
	}
}
