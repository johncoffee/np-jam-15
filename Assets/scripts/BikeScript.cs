using UnityEngine;
using System.Collections;

public class BikeScript : MonoBehaviour {

	public float speed = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += Vector3.forward * speed * Time.fixedDeltaTime;
	}
}
