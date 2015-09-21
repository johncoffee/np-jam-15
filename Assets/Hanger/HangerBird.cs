using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HangerBird : MonoBehaviour
{
    public float speed = 10;
    public Transform steering;

    public Transform frontWheel;

    public Vector3 steeringValue;
    public float steeringFactor;
    private Vector3 softSteering;
    private float softUpX;
    private Quaternion softRot;

    private void Update()
    {
        if (steering != null)
        {
            //var angle = new Vector3(Mathf.DeltaAngle(0, steering.eulerAngles.x), Mathf.DeltaAngle(0, steering.eulerAngles.y), Mathf.DeltaAngle(0, steering.eulerAngles.z));
            //Debug.Log("STEERING " + angle);
            softSteering = softSteering * 0.8f + steering.forward * 0.2f;
            softUpX = softUpX * 0.8f + steering.up.x * 0.2f;
            softRot = Quaternion.Lerp(softRot, steering.localRotation, 0.2f);
            steeringValue = softSteering;
            steeringValue.x += softUpX;
            if (frontWheel != null)
            {
                frontWheel.localPosition = steeringValue;
                frontWheel.localRotation = softRot;
            }
        }

        transform.Translate(softSteering * Time.deltaTime * speed);
    }
}
