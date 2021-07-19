using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    bool playerInControl = false;
    public float jumpForce;
    public float jumpInputBufferTime;
    public float jumpBeatBufferTime;
    public bool isCalibration = false;

    Rigidbody2D rb;
    BasicMoveset controls;
    bool jumpInputBuffered = false;
    bool otherInputBuffered = false;
    bool jumpBeatBuffered = false;
    bool isRecording = true;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Basic.Jump.performed += _ => JumpPerformed();

        // Other check
        controls.Basic.DashLeft.performed += _ => OtherPerformed();
        controls.Basic.DashRight.performed += _ => OtherPerformed();
        controls.Basic.Stunt.performed += _ => OtherPerformed();

        controls.Debug.StartRecording.performed += _ => ChangeRecordState(true);
        controls.Debug.PlayRecording.performed += _ => ChangeRecordState(false);
    }

    private void OnEnable()
    {
        controls.Enable();
        BeatController.Instance.playerInputEvent += JumpBeat;
    }

    private void OnDisable()
    {
        controls.Disable();
        BeatController.Instance.playerInputEvent -= JumpBeat;
    }

    private void JumpPerformed()
    {
        if (isRecording && playerInControl)
            ApplyJumpForce();
        else if ((!isRecording && !jumpInputBuffered) || (isCalibration && !jumpInputBuffered))
            StartCoroutine(JumpInputBuffer());
    }

    private void OtherPerformed()
    {
        if (!isRecording && !otherInputBuffered)
            StartCoroutine(OtherInputBuffer());
    }

    private void JumpBeat()
    {
        StartCoroutine(JumpBeatBuffer());
    }

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (jumpBeatBuffered && jumpInputBuffered)
        {
            if (!otherInputBuffered)
            {
                ApplyJumpForce();
            }
            jumpInputBuffered = false;
            jumpBeatBuffered = false;
        }
    }

    public IEnumerator JumpInputBuffer()
    {
        jumpInputBuffered = true;
        yield return new WaitForSeconds(jumpInputBufferTime);
        jumpInputBuffered = false;
    }

    public IEnumerator OtherInputBuffer()
    {
        otherInputBuffered = true;
        yield return new WaitForSeconds(jumpInputBufferTime);
        otherInputBuffered = false;
    }

    public IEnumerator JumpBeatBuffer()
    {
        jumpBeatBuffered = true;
        yield return new WaitForSeconds(jumpBeatBufferTime);
        jumpBeatBuffered = false;
    }

    public void ApplyJumpForce()
    {
        if(rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce((Vector2.up * jumpForce), ForceMode2D.Impulse);
        }
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
