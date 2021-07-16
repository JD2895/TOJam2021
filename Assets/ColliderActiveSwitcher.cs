using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderActiveSwitcher : MonoBehaviour
{
    public Collider2D col;

    BasicMoveset controls;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => ChangeColliderActive(true);
        controls.Debug.PlayRecording.performed += _ => ChangeColliderActive(false);
    }

    private void Start()
    {
        ChangeColliderActive(true);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void ChangeColliderActive(bool isRecording)
    {
        col.enabled = !isRecording;
    }
}
