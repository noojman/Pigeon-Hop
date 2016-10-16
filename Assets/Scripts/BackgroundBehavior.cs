using UnityEngine;
using System.Collections;

public class BackgroundBehavior : MonoBehaviour {
	
	public Vector3 startingPosition;
	
	public static Vector3 speed;
	
	// Use this for initialization
	void Start() {
		speed = new Vector3 (-1, 0, 0);
	}
	
	// Do physics engine updates here
	void FixedUpdate () {
		transform.position += speed * Time.deltaTime;
		if (transform.position.x <= -8.35f) {
			transform.position = startingPosition;
		}
	}
}