using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
	public Sprite punch;
	public Sprite punchEmpty;
	public Counter counter;
	public bool correct = false;

	private bool punched = false;
	void OnMouseDown()
	{
		if (!punched)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (correct)
					counter.correct++;
				else
					counter.wrong++;

				punched = true;
				GetComponent<SpriteRenderer>().sprite = punchEmpty;
			}
		}
	}

	private void OnDestroy()
	{
		if (correct && !punched)
			counter.wrong++;
	}
}
