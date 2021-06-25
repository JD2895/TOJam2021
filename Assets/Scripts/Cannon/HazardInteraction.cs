using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardInteraction : MonoBehaviour
{
    bool isInteractable = false;

    BasicMoveset controls;
    Rigidbody2D rb;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => ChangeInteractionState(false);
        controls.Debug.PlayRecording.performed += _ => ChangeInteractionState(true);

        rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        controls.Enable();
        BeatController.Instance.playbackRestartEvent += () => { ChangeInteractionState(true); };
    }

    private void OnDisable()
    {
        controls.Disable();
        BeatController.Instance.playbackRestartEvent -= () => { ChangeInteractionState(true); };
    }

    public void ChangeInteractionState(bool setInteratable)
    {
        isInteractable = setInteratable;
    }

    public void CheckForHazardOnPlayer()
    {
        RaycastHit2D[] hitResults = new RaycastHit2D[5];
        int numberHit = rb.Cast(Vector2.right, hitResults, 0f);
        if(numberHit > 0)
        {
            for (int i = 0; i < numberHit; ++i)
            {
                if (hitResults[i].collider.CompareTag("Hazard") && SettingsController.Instance.HazardCollisionEnabled)
                {
                    BeatController.Instance.RestartRequest();
                }
            }
        }
    }

    private void Start()
    {
        ChangeInteractionState(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard") && isInteractable && SettingsController.Instance.HazardCollisionEnabled)
        {
            BeatController.Instance.RestartRequest();
        }
    }
}
