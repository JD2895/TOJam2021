using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecorderSFX : MonoBehaviour
{
    public AudioSource recordingSFX;
    public AudioSource playbackSFX;
    public bool recordingState = true;

    bool currentState = true;
    BasicMoveset controls;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => PlaySFX(recordingState);
        controls.Debug.PlayRecording.performed += _ => PlaySFX(!recordingState);
        currentState = recordingState;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void PlaySFX(bool recording)
    {
        if (recording)
            recordingSFX.Play();
        else
            playbackSFX.Play();
    }
}
