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

    public Transform frontWheel;

    public float steeringValue;
    public float steeringFactor;
    private float softSteering = 0;

    public AudioSource voiceOne;
    public AudioSource voiceTwo;
    public AudioSource p1Shouting;
    public AudioSource p2Shouting;

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

    IEnumerator Start()
    {
        yield return new WaitForSeconds(10);

        voiceOne.Play();
        voiceTwo.Play();

        voiceOne.volume = isPlayerOne ? 1 : 0;
        voiceTwo.volume = isPlayerOne ? 0 : 1;
    }


	// Update is called once per frame
	void Update ()
    {
        if (steering != null && frontWheel != null)
        {
            float angle = Mathf.DeltaAngle(0, steering.eulerAngles.y) + Mathf.DeltaAngle(0, steering.eulerAngles.z);
            //Debug.Log("STEERING " + angle);
            softSteering = softSteering*0.8f + angle*0.2f;
            steeringValue = Mathf.Clamp(softSteering * steeringFactor, -1, 1);
            frontWheel.localEulerAngles = new Vector3(0, steeringValue * 30, 0);
        }
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            voiceOne.volume = 1;
            voiceTwo.volume = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            voiceOne.volume = 0;
            voiceTwo.volume = 1;
        }
    }
}
