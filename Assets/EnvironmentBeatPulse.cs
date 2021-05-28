using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentBeatPulse : MonoBehaviour
{
    public Animator beatEventAnimator;

    private void OnEnable()
    {
        BeatController.Instance.environmentEvent += EnvironmentBeatEvent;
    }

    private void OnDisable()
    {
        BeatController.Instance.environmentEvent -= EnvironmentBeatEvent;
    }

    private void EnvironmentBeatEvent()
    {
        beatEventAnimator.SetTrigger("JumpPadBeatDetected");
    }
}
