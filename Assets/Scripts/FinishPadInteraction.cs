using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FinishPadInteraction : MonoBehaviour
{
    bool isInteractable = false;

    CircleCollider2D mainCollider;
    Rigidbody2D rb;
    MovementRecorder movementRecorder;
    SideMovement sideMovement;
    Jump jump;
    ArtificialGravity artificialGravity;
    BasicMoveset controls;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => ChangeInteractionState(true);
        controls.Debug.PlayRecording.performed += _ => ChangeInteractionState(false);
    }

    private void OnEnable()
    {
        controls.Enable();
        BeatController.Instance.playbackRestartEvent += () => { ChangeInteractionState(false); };
    }

    private void OnDisable()
    {
        controls.Disable();
        BeatController.Instance.playbackRestartEvent -= () => { ChangeInteractionState(false); };
    }

    private void ChangeInteractionState(bool isRecording = false)
    {
        isInteractable = !isRecording;
    }

    private void Start()
    {
        ChangeInteractionState(true);
           mainCollider = this.GetComponent<CircleCollider2D>();
        rb = this.GetComponent<Rigidbody2D>();
        movementRecorder = this.GetComponentInChildren<MovementRecorder>();
        sideMovement = this.GetComponent<SideMovement>();
        artificialGravity = this.GetComponent<ArtificialGravity>();
        jump = this.GetComponent<Jump>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish Pad") && isInteractable)
        {
            //rb.bodyType = RigidbodyType2D.Static;
            mainCollider.enabled = false;
            movementRecorder.enabled = false;
            if (sideMovement != null)
                sideMovement.enabled = false;
            if (jump != null)
                jump.enabled = false;
            //artificialGravity.enabled = false;
            StartCoroutine(SlightDelayBeforeFinish());
        }
    }

    public  IEnumerator SlightDelayBeforeFinish()
    {
        yield return new WaitForSeconds(1f);
        SettingsController.Instance.TriggerLevelFinish();
    }
}
