using UnityEngine;
using System.Collections;

public class BikeScript : MonoBehaviour {

	public Vector3 vel = new Vector3();
	public Vector3 acc = new Vector3();

	public float leftRight = 5f;

	public float max0 = -1f, max1 = 1f;

	float damped = 0f;

	public GameObject bikeBase;

	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		accelerate += Vector3.right * leftRight;
		vel += acc;
		vel = new Vector3( vel.x * 0.91f, vel.y, vel.z ); // damping
		transform.position += vel * Time.fixedDeltaTime;
//		speed = new Vector3( Mathf.Max(speed.x, maxTurningSpeed), speed.y, speed.x);
		damped = damped * 0.8f + vel.x * 0.2f;
		Debug.Log(damped);
		bikeBase.transform.eulerAngles = new Vector3(0, 0, -damped * 20f);
//		bikeBase.transform.position += new Vector3(1);
		acc *= 0;
	}
	
	void Update() {
		if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > max0) {
			float inputAcc = -leftRight;
			acc += Vector3.right * inputAcc * Time.deltaTime;
//			accelerate += new Vector3(accelerate.x * 1.2f, 0f ,0f);
		}
		else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < max1) {
			float inputAcc = leftRight;
			acc += Vector3.right * inputAcc * Time.deltaTime;
//			accelerate += new Vector3(accelerate.x * 1.2f, 0f ,0f);
		}

//		if (Input.GetKey(KeyCode.UpArrow)) {
//			accelerate += Vector3.forward * accelerate * Time.deltaTime;
//		}
//		if (Input.GetKey(KeyCode.DownArrow)) {
//			accelerate += Vector3.forward * -accelerate * Time.deltaTime;
//		}
	}
}
