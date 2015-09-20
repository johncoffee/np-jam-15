using UnityEngine;
using System.Collections;

public class TimeLine : MonoBehaviour
{
    public float delay;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        Trigger();
    }

    public virtual void Trigger()
    {

    }
}
