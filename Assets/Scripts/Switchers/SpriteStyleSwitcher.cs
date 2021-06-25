using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteStyleSwitcher : MonoBehaviour
{
    public Sprite enabledSprite;
    public Sprite disabledSprite;
    public bool recordingEnabled = true;

    bool currentState = true;
    SpriteRenderer sprRenderer;
    BasicMoveset controls;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => ChangeSpriteStyle(recordingEnabled);
        controls.Debug.PlayRecording.performed += _ => ChangeSpriteStyle(!recordingEnabled);
        currentState = recordingEnabled;
    }

    private void Start()
    {
        sprRenderer = this.GetComponent<SpriteRenderer>();
        ChangeSpriteStyle(currentState);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void ChangeSpriteStyle(bool enabled)
    {
        if (enabled)
            sprRenderer.sprite = enabledSprite;
        else
            sprRenderer.sprite = disabledSprite;
    }
}
