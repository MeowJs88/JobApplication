using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour {

	public float speed;

	public List<GameObject> tailObjects = new List<GameObject>();
	public GameObject tailPrefab;
	Vector3 direction;
	// Use this for initialization
	void Start () {
		
		tailObjects.Add(gameObject);
	}
	
	void Update () {
		

		if (Input.GetKey(KeyCode.W)){
			direction = Vector3.forward;
		}
		if (Input.GetKey(KeyCode.S)){
			direction = Vector3.back;
		}
		if (Input.GetKey(KeyCode.A))
		{
			direction = Vector3.left;
		}
		if (Input.GetKey(KeyCode.D))
		{
			direction = Vector3.right;
		}
		transform.Translate(direction * speed * Time.deltaTime);

	}

	void OnTriggerEnter(Collider other)
	{

		if (other.GetComponent<Wood>() != null)
		{
			GameControl.gameControl.CheckLife();
		}
	}

	public void AddTail(){
		GameControl.gameControl.ScoreUp(5);
		Vector3 newTailPosition = tailObjects[tailObjects.Count-1].transform.position;
		speed += 0.2f;
		GameObject tail = Instantiate(tailPrefab, newTailPosition, Quaternion.identity);
		tail.GetComponent<TailMovement>().mainSnake = this;
		tailObjects.Add(tail);

	
	}
}
