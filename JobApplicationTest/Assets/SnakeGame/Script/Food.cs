﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.GetComponent<SnakeMovement>() != null)
		{
			other.GetComponent<SnakeMovement>().AddTail();
			Destroy(gameObject);
		}
	}
}
