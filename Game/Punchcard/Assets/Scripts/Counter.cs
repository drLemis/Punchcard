using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
	public TextMeshProUGUI textPercent;
	public float percent;
	public int correct;
	public int wrong;

	private void Update()
	{
		percent = Mathf.Floor(100f / (float)(correct + wrong) * (float)correct);

		if (float.IsNaN(percent))
			percent = 0;

		textPercent.text = percent.ToString() + "%";
	}
}
