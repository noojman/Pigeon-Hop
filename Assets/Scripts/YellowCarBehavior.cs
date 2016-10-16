using UnityEngine;
using System.Collections;

public class YellowCarBehavior : MonoBehaviour {
	
	public Vector3 startingPosition;
	
	public static Vector3 speed;
	
	bool speedIndex = true;
	
	// Use this for initialization
	void Start () {
		transform.position = startingPosition;
		if (speedIndex == true) {
			speed = new Vector3 (-Random.Range (5, 10), 0, 0);
			speedIndex = false;
		} else {
			speed = new Vector3 (-Random.Range (3, 8), 0, 0);
			speedIndex = true;
		}
	}
	
	// Do physics engine updates here
	void FixedUpdate () {
		transform.position += speed * Time.deltaTime;
		if (transform.position.x <= -3) {
			Start();
		}
	}
}