using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunt : MonoBehaviour
{
    public float stuntBeatBufferedTime;
    public float stuntInputBufferTime;
    public ParticleSystem particleS;
    public Animator animator;

    BasicMoveset controls;
    bool playerInControl = false;
    bool stuntBeatBuffered = false;
    bool stuntInputBuffered = false;
    bool otherInputBuffered = false;
    bool isRecording = true;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Basic.Stunt.performed += _ => StuntPerformed();

        // Other check
        controls.Basic.DashLeft.performed += _ => OtherPerformed();
        controls.Basic.DashRight.performed += _ => OtherPerformed();
        controls.Basic.Jump.performed += _ => OtherPerformed();

        controls.Debug.StartRecording.performed += _ => ChangeRecordState(true);
        controls.Debug.PlayRecording.performed += _ => ChangeRecordState(false);
    }

    private void OnEnable()
    {
        controls.Enable();
        BeatController.Instance.playerInputEvent += StuntBeat;
    }

    private void OnDisable()
    {
        controls.Disable();
        BeatController.Instance.playerInputEvent -= StuntBeat;
    }

    private void StuntPerformed()
    {
        if (!isRecording && !stuntInputBuffered)
            StartCoroutine(StuntInputBuffer());
    }

    private void OtherPerformed()
    {
        if (!isRecording && !otherInputBuffered)
            StartCoroutine(OtherInputBuffer());
    }

    private void Update()
    {
        if (stuntBeatBuffered && stuntInputBuffered)
        {
            if(!otherInputBuffered)
            {
                DoStunt();
            }
            stuntInputBuffered = false;
            stuntBeatBuffered = false;
            otherInputBuffered = false;
        }
    }

    private void DoStunt()
    {
        animator.SetTrigger("changePhase");
        ScoreController.Instance?.AddStuntScore();
        particleS.Emit(10);
    }

    public IEnumerator StuntInputBuffer()
    {
        stuntInputBuffered = true;
        yield return new WaitForSeconds(stuntInputBufferTime);
        stuntInputBuffered = false;
    }

    public IEnumerator OtherInputBuffer()
    {
        otherInputBuffered = true;
        yield return new WaitForSeconds(stuntInputBufferTime);
        otherInputBuffered = false;
    }

    public IEnumerator StuntBeatBuffer()
    {
        stuntBeatBuffered = true;
        yield return new WaitForSeconds(stuntBeatBufferedTime);
        stuntBeatBuffered = false;
    }

    public void SetPlayerInControl(bool toSet)
    {
        if (toSet)
        {
            controls.Basic.Enable();
        }
        else
        {
            controls.Basic.Disable();
        }
        playerInControl = toSet;
    }

    private void StuntBeat()
    {
        StartCoroutine(StuntBeatBuffer());
    }

    private void ChangeRecordState(bool toSet)
    {
        isRecording = toSet;
    }
}
