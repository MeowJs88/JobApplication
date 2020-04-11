using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TailMovement : MonoBehaviour {

	public float speed;

	public GameObject tailTarget;
	public Vector3 tailTargetPosition;
	public SnakeMovement mainSnake;
	

	
	void Start () {
	
		tailTarget = mainSnake.tailObjects[mainSnake.tailObjects.Count-2];
		
	}
	

	void Update () {
		
		speed = mainSnake.speed + 2.5f;
		tailTargetPosition = tailTarget.transform.position;
		transform.LookAt(tailTargetPosition);
		transform.position = Vector3.Lerp(transform.position, tailTargetPosition, Time.deltaTime * speed);
	}


}
