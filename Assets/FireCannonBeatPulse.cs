using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannonBeatPulse : MonoBehaviour
{
    public Animator beatEventAnimator;

    private void OnEnable()
    {
        BeatController.Instance.fireCannonEvent += FireCannonBeatEvent;
    }

    private void OnDisable()
    {
        BeatController.Instance.fireCannonEvent -= FireCannonBeatEvent;
    }

    private void FireCannonBeatEvent()
    {
        beatEventAnimator.SetTrigger("FireCannonBeatDetected");
    }
}
