using UnityEngine;
using System.Collections;

public class RandomStartPosition : MonoBehaviour {
	public Vector3 addRandom;
	
	// Use this for initialization
	void Start () {
		transform.position += new Vector3(
			addRandom.x * Random.value,
			addRandom.y * Random.value,
			addRandom.z * Random.value
		);
	}

}
