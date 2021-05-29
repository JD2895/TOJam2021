using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SideMovement : MonoBehaviour
{
    bool playerInControl = true;
    public float sideMoveAcceleration;
    public float sideMoveMax;
    public float noInputFrictionMultiplier;
    public bool isCailbration = false;

    Rigidbody2D rb;
    BasicMoveset controls;
    Vector3 newVelocity;
    MoveDir toMoveDir = MoveDir.None;

    private void Awake()
    {
        controls = new BasicMoveset();

        if (playerInControl)
        {
            controls.Basic.Left.performed += _ => MoveLeftStart();
            controls.Basic.Right.performed += _ => MoveRightStart();
            controls.Basic.Left.canceled += _ => MoveLeftEnd();
            controls.Basic.Right.canceled += _ => MoveRightEnd();
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (toMoveDir != MoveDir.None)
        {
            newVelocity = rb.velocity;

            if (toMoveDir == MoveDir.Left)
            {
                if (newVelocity.x > (sideMoveMax * -1f))
                    newVelocity.x -= sideMoveAcceleration * Time.fixedDeltaTime;
                else
                    newVelocity.x += sideMoveAcceleration * Time.fixedDeltaTime;
            }
            else if (toMoveDir == MoveDir.Right)
            {
                if (newVelocity.x < (sideMoveMax * 1f))
                    newVelocity.x += sideMoveAcceleration * Time.fixedDeltaTime;
                else
                    newVelocity.x -= sideMoveAcceleration * Time.fixedDeltaTime;
            }

            rb.velocity = newVelocity;
        }
        else
        {
            newVelocity = rb.velocity;

            if (Mathf.Abs(newVelocity.x) < 0.3)
                newVelocity.x = 0;
            else
                newVelocity.x /= noInputFrictionMultiplier;

            rb.velocity = newVelocity;
        }
    }

    public void MoveLeftStart()
    {
        toMoveDir = MoveDir.Left;
    }

    public void MoveRightStart()
    {
        toMoveDir = MoveDir.Right;
    }

    public void MoveLeftEnd()
    {
        if (toMoveDir == MoveDir.Left)
            toMoveDir = MoveDir.None;
    }

    public void MoveRightEnd()
    {
        if (toMoveDir == MoveDir.Right)
            toMoveDir = MoveDir.None;
    }

    public void SetPlayerInControl(bool toSet)
    {
        if (toSet || isCailbration)
        {
            controls.Enable();
        }
        else
        {
            controls.Disable();
        }
        toMoveDir = MoveDir.None;
        playerInControl = toSet;
    }

    public enum MoveDir
    {
        Left,
        None,
        Right
    }
}
