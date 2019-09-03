using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
	[Range(0, 0.5f)]
	public float scrollSpeed = 0.5f;
	private float offset;

	void Update()
	{
		offset += (Time.deltaTime * scrollSpeed);
		offset = offset % 1f;
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, offset));
	}
}
