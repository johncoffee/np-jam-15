using UnityEngine;
using System.Collections;

public class BikeScript : MonoBehaviour {

	public Vector3 speed = new Vector3();
	public float accelerate = 0.2f;
	public float leftRight = 0.1f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += speed * Time.fixedDeltaTime;
	}

	void Update() {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.right * -leftRight * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * leftRight * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			speed += Vector3.forward * accelerate * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			speed += Vector3.forward * -accelerate * Time.deltaTime;
		}
	}
}
