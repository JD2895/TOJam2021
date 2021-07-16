using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
    public Animator anim;

    BasicMoveset controls;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => ChangeAnimation(true);
        controls.Debug.PlayRecording.performed += _ => ChangeAnimation(false);
    }

    private void Start()
    {
        ChangeAnimation(true);
    }

    private void OnEnable()
    {
        controls.Enable();
        BeatController.Instance.playbackRestartEvent += () => { ChangeAnimation(false); };
    }

    private void OnDisable()
    {
        controls.Disable();
        BeatController.Instance.playbackRestartEvent -= () => { ChangeAnimation(false); };
    }

    private void ChangeAnimation(bool isRecording)
    {
        if (isRecording)
            anim.SetTrigger("switchAnimationIsRecording");
        else
            anim.SetTrigger("switchAnimationPlayback");
    }
}
