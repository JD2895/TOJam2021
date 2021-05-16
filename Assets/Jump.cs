using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public float jumpForce;
    public float jumpInputBufferTime;
    public float jumpBeatBufferTime;

    Rigidbody2D rb;
    BasicMoveset controls;
    bool jumpInputBuffered = false;
    bool jumpBeatBuffered = false;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Basic.Jump.performed += _ => JumpPerformed();
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
        if (!jumpInputBuffered)
            StartCoroutine(JumpInputBuffer());
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
            ApplyJumpForce();
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

    public IEnumerator JumpBeatBuffer()
    {
        jumpBeatBuffered = true;
        yield return new WaitForSeconds(jumpBeatBufferTime);
        jumpBeatBuffered = false;
    }

    public void ApplyJumpForce()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce((Vector2.up * jumpForce), ForceMode2D.Impulse);
    }
}
