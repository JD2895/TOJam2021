﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    bool playerInControl = false;
    public float dashDistance;
    public float dashInputBufferTime;
    public float dashBeatBufferTime;
    public bool isCalibration = false;

    Rigidbody2D rb;
    BasicMoveset controls;
    bool dashRightInputBuffered = false;
    bool dashLeftInputBuffered = false;
    bool dashBeatBuffered = false;
    bool isRecording = true;

    private void Awake()
    {
        controls = new BasicMoveset();
        //controls.Basic.Jump.performed += _ => JumpPerformed();
        controls.Basic.DashLeft.performed += _ => DashLeftPerformed();
        controls.Basic.DashRight.performed += _ => DashRightPerformed();

        controls.Debug.StartRecording.performed += _ => ChangeRecordState(true);
        controls.Debug.PlayRecording.performed += _ => ChangeRecordState(false);
    }

    private void OnEnable()
    {
        controls.Enable();
        BeatController.Instance.playerInputEvent += DashBeat;
    }

    private void OnDisable()
    {
        controls.Disable();
        BeatController.Instance.playerInputEvent -= DashBeat;
    }

    private void DashLeftPerformed()
    {
        if (isRecording && playerInControl)
            ApplyDash(-1f);
        else if (!isRecording && !dashLeftInputBuffered && !dashRightInputBuffered)
            StartCoroutine(DashLeftInputBuffer());
    }

    private void DashRightPerformed()
    {
        if (isRecording && playerInControl)
            ApplyDash(1f);
        else if (!isRecording && !dashLeftInputBuffered && !dashRightInputBuffered)
            StartCoroutine(DashRightInputBuffer());
    }

    private void DashBeat()
    {
        StartCoroutine(DashBeatBuffer());
    }

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (dashBeatBuffered && dashLeftInputBuffered)
        {
            ApplyDash(-1f);
            dashLeftInputBuffered = false;
            dashBeatBuffered = false;
        }

        if (dashBeatBuffered && dashRightInputBuffered)
        {
            ApplyDash(1f);
            dashRightInputBuffered = false;
            dashBeatBuffered = false;
        }
    }

    public IEnumerator DashLeftInputBuffer()
    {
        dashLeftInputBuffered = true;
        yield return new WaitForSeconds(dashInputBufferTime);
        dashLeftInputBuffered = false;
    }

    public IEnumerator DashRightInputBuffer()
    {
        dashRightInputBuffered = true;
        yield return new WaitForSeconds(dashInputBufferTime);
        dashRightInputBuffered = false;
    }

    public IEnumerator DashBeatBuffer()
    {
        dashBeatBuffered = true;
        yield return new WaitForSeconds(dashBeatBufferTime);
        dashBeatBuffered = false;
    }

    public void ApplyDash(float direction)
    {
        Vector2 oldVelocity = rb.velocity;
        rb.velocity = Vector2.zero;
        rb.MovePosition((Vector2)this.transform.position + (Vector2.right * dashDistance * Mathf.Sign(direction)));
        rb.velocity = oldVelocity;
    }

    public void SetPlayerInControl(bool toSet)
    {
        if (toSet || isCalibration)
        {
            controls.Basic.Enable();
        }
        else
        {
            controls.Basic.Disable();
        }
        playerInControl = toSet;
    }

    private void ChangeRecordState(bool toSet)
    {
        isRecording = toSet;
    }
}
