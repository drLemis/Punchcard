﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PunchSpawn : MonoBehaviour
{
	public Counter counter;
	public GameObject punch;
	public GameObject mark;
	public float space = 1f;

	[Range(0, 100)]
	public float correctPercentChance = 10f;

	[Range(0, 10)]
	public int amount = 1;
	public float timer = 1f;
	private float currentTimer = 1f;

	public int maxSpawn = 10;
	private int currentSpawn = 0;

	private bool active = true;

	void Start()
	{
		currentTimer = timer;
		currentSpawn = 0;
		active = true;
	}

	void Update()
	{
		if (active)
		{
			currentTimer -= Time.deltaTime;

			if (currentTimer <= 0)
			{
				currentTimer = timer;

				if (currentSpawn++ >= maxSpawn)
					active = false;

				for (int i = 0; i < amount; i++)
				{
					GameObject newPunch = Instantiate(punch, transform);

					if (Random.Range(0, 100) <= correctPercentChance)
					{
						newPunch.GetComponent<PlayerClick>().correct = true;
						// newPunch.GetComponent<SpriteRenderer>().color = Color.green;

						GameObject newMark = Instantiate(mark, transform);
						newMark.transform.position = transform.position + new Vector3(space * i, 0, 0.5f);
						Destroy(newMark, 6f);
					}

					newPunch.GetComponent<PlayerClick>().counter = counter;

					newPunch.transform.position = transform.position + new Vector3(space * i, 0, 0);
					Destroy(newPunch, 6f);
				}
			}
		}
		else
		{
			if (transform.childCount == 0)
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
