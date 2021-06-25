using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardBeatPulse : MonoBehaviour
{
    public Animator beatEventAnimator;

    private void OnEnable()
    {
        BeatController.Instance.hazardEvent += FireCannonBeatEvent;
    }

    private void OnDisable()
    {
        BeatController.Instance.hazardEvent -= FireCannonBeatEvent;
    }

    private void FireCannonBeatEvent()
    {
        beatEventAnimator.SetTrigger("HazardBeatDetected");
    }
}
