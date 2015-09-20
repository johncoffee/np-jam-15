using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VildNinja.GyroPhone;

public class PlayerManager : MonoBehaviour
{

    public static bool isPlayerOne;

    public GameObject[] enableForPlayerOne;
    public GameObject[] enableForPlayerTwo;
    public GameObject[] disableForPlayerOne;
    public GameObject[] disableForPlayerTwo;

    public Transform steering;

    private Transform frontWheel;

    public float steeringValue;
    public float steeringFactor;

    public AudioSource myVoice;
    public AudioSource otherVoice;

    public List<TimeLine> playerOneTimeLine = new List<TimeLine>();
    public List<TimeLine> playerTwoTimeLine = new List<TimeLine>();

    // Use this for initialization
    void Awake ()
    {
        if (isPlayerOne)
        {
            foreach (var go in enableForPlayerOne)
                go.SetActive(true);
            foreach (var go in disableForPlayerOne)
                go.SetActive(false);
        }
        else
        {
            foreach (var go in enableForPlayerTwo)
                go.SetActive(true);
            foreach (var go in disableForPlayerTwo)
                go.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (steering != null)
        {
            float angle = Mathf.DeltaAngle(0, steering.eulerAngles.y) + Mathf.DeltaAngle(0, steering.eulerAngles.z);
            Debug.Log("STEERING " + angle);
            steeringValue = Mathf.Clamp(angle * steeringFactor, -1, 1);
        }

	    foreach (var tl in (isPlayerOne ? playerOneTimeLine : playerTwoTimeLine))
	    {
	        if (!tl.used && tl.transform.localPosition.y < Time.timeSinceLevelLoad)
	        {
	            tl.used = true;
                tl.Trigger();
	        }
	    }
    }

    [ContextMenu("TimeLine Setup")]
    public void SetupTimeLines()
    {
        playerOneTimeLine = new List<TimeLine>();
        playerTwoTimeLine = new List<TimeLine>();
        foreach (var tl in FindObjectsOfType<TimeLine>())
        {
            (tl.isPlayerOne ? playerOneTimeLine : playerTwoTimeLine).Add(tl);
            tl.transform.parent = transform;
            var pos = tl.transform.localPosition;
            pos.x = tl.isPlayerOne ? 0 : 20;
            tl.transform.localPosition = pos;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        for (int i = 0; i < 300; i += 10)
        {
            Gizmos.color = i%60 == 0 ? Color.green : Color.yellow;
            Gizmos.DrawRay(new Vector3(-5, i, 0), new Vector3(30, 0, 0));
        }

        Gizmos.color = Color.red;
        Gizmos.DrawRay(Vector3.zero, new Vector3(0, 300, 0));
        Gizmos.DrawRay(new Vector3(20, 0, 0), new Vector3(0, 300, 0));

        Gizmos.DrawWireCube(new Vector3(10, Time.timeSinceLevelLoad, 0), new Vector3(32, 2, 0));
    }
}
