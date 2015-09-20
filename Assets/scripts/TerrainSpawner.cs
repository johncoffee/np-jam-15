using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainSpawner : MonoBehaviour {

	public GameObject trackingTarget;

	public int segmentsAhead = 2;

	public float segmentLength = -1f;

	public GameObject segmentPrefab;

	public List<GameObject> list;

	// Use this for initialization
	void Start () {
//		list = new List<GameObject>(segmentsAhead);
//		for (var i =0; i < segmentsAhead; i++) {
//			appendSegment();
//		}
	}
	
	// Update is called once per frame
	void Update () {
		float z = trackingTarget.transform.position.z;
		bool isTargetCloseToEdge = (list.Count * segmentLength - z < segmentLength * segmentsAhead);
		if (isTargetCloseToEdge) {
			appendSegment();
		}
	}

	void appendSegment () {
		GameObject newSegment = createSegment();

		if (list.Count > 0) {
			GameObject lastLoc = list[list.Count-1];	
			newSegment.transform.position = lastLoc.transform.position + Vector3.forward * segmentLength;
		}

		list.Add(newSegment);
	}

	GameObject createSegment () {
		return (GameObject) Instantiate(segmentPrefab);
	}
}
