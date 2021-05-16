using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBeatPulse : MonoBehaviour
{
    public Animator beatEventAnimator;

    private void OnEnable()
    {
        BeatController.Instance.jumpPadEvent += JumpPadBeatEvent;
    }

    private void OnDisable()
    {
        BeatController.Instance.jumpPadEvent -= JumpPadBeatEvent;
    }

    private void JumpPadBeatEvent()
    {
        beatEventAnimator.SetTrigger("JumpPadBeatDetected");
    }
}
