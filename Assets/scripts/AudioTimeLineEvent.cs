using UnityEngine;
using System.Collections;

public class AudioTimeLineEvent : TimeLine
{

    public AudioClip clip;
    public AudioSource source;

    public override void Trigger()
    {
        source.PlayOneShot(clip);
    }
    
}
