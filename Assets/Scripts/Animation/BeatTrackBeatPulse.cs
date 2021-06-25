using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTrackBeatPulse : MonoBehaviour
{
    public Animator beatEventAnimator;
    public int beatNumber;

    private void OnEnable()
    {
        BeatController.Instance.beatEvent += BeatEvent;
    }

    private void OnDisable()
    {
        BeatController.Instance.beatEvent -= BeatEvent;
    }

    private void BeatEvent(int detectedBeatNumber)
    {
        if (detectedBeatNumber == beatNumber)
            beatEventAnimator.SetTrigger("BeatDetected");
    }
}
