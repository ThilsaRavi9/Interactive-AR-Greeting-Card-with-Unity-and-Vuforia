using UnityEngine;
using Vuforia;
using System.Collections;
using System.Collections.Generic;

public class GreetingCardScript : DefaultObserverEventHandler
{
    public AudioSource greetingAudio;

    protected override void OnTrackingFound()
    {
        if (!greetingAudio.isPlaying)
        {
            greetingAudio.Play();
        }
        base.OnTrackingFound();
    }

    protected override void OnTrackingLost()
    {
        greetingAudio.Stop();
        base.OnTrackingLost();
    }
}