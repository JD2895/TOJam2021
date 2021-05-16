using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteStyleSwitcher : MonoBehaviour
{
    public Sprite fullSprite;
    public Sprite bwSprite;
    SpriteRenderer sprRenderer;

    BasicMoveset controls;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => ChangeSpriteStyle(true);
        controls.Debug.PlayRecording.performed += _ => ChangeSpriteStyle(false);
    }

    private void Start()
    {
        sprRenderer = this.GetComponent<SpriteRenderer>();
        ChangeSpriteStyle(true);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void ChangeSpriteStyle(bool isRecording)
    {
        if (isRecording)
            sprRenderer.sprite = bwSprite;
        else
        {
            sprRenderer.sprite = fullSprite;
        }
    }
}
