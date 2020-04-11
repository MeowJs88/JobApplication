using System.Collections;
using UnityEngine;

public class FoodGeneration : MonoBehaviour {

	public float xpos = 14.0f;
	public float zpos = 25;

	public GameObject foodPrefab;
	public GameObject currentFood;
	public Vector3 currentFoodPosition;

	void AddNewFood(){
		RandomPosition();
		currentFood = GameObject.Instantiate(foodPrefab, currentFoodPosition, Quaternion.identity) as GameObject;

	}
	void RandomPosition(){
		currentFoodPosition = new Vector3(Random.Range(-xpos, xpos), 3.89f, Random.Range(-zpos, zpos));

	}
	// Update is called once per frame
	void Update () {
		if(!currentFood){
			AddNewFood();
		}
	}
}
