using UnityEngine;
using System.Collections;

public class RotateLikeSunScript : MonoBehaviour {

	public float speed = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(transform.position, new Vector3(0.2f, 0.8f, 0f), speed * Time.deltaTime);
	}
}
