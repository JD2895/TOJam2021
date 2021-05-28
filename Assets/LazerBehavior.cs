using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBehavior : MonoBehaviour
{
    BasicMoveset controls;
    bool recordingState = true;
    public Animator lazerAnimator;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => SetRecordingState(true);
        controls.Debug.PlayRecording.performed += _ => SetRecordingState(false);
    }

    private void Start()
    {
        recordingState = true;
    }

    private void OnEnable()
    {
        controls.Enable();
        BeatController.Instance.fireCannonEvent += FireLazer;
        BeatController.Instance.playbackRestartEvent += SetLazerIdle;
    }

    private void OnDisable()
    {
        controls.Disable();
        BeatController.Instance.fireCannonEvent -= FireLazer;
        BeatController.Instance.playbackRestartEvent -= SetLazerIdle;
    }

    private void FireLazer()
    {
        if (recordingState)
        {
            lazerAnimator.SetTrigger("FireDullLazer");
        }
        else
        {
            lazerAnimator.SetTrigger("FireLazer");
        }
    }

    private void SetRecordingState(bool toSet)
    {
        recordingState = toSet;
        SetLazerIdle();
    }

    private void SetLazerIdle()
    {
        lazerAnimator.SetTrigger("SetIdle");
    }
}
