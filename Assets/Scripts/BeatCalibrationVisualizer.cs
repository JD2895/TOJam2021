using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatCalibrationVisualizer : MonoBehaviour
{
    BasicMoveset controls;

    public Animator inputEventAnimator;
    public Animator beatEventAnimator;

    private void OnEnable()
    {
        BeatController.Instance.playerInputEvent += JumpBeatEvent;
        controls.Enable();
    }

    private void OnDisable()
    {
        BeatController.Instance.playerInputEvent -= JumpBeatEvent;
        controls.Disable();
    }

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Basic.Jump.performed += _ => JumpInputEvent();
    }

    private void JumpBeatEvent()
    {
        beatEventAnimator.SetTrigger("BeatDetected");
    }

    private void JumpInputEvent()
    {
        inputEventAnimator.SetTrigger("InputDetected");
    }
}
