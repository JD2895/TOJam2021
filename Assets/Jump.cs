using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce;

    Rigidbody2D rb;
    BasicMoveset controls;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Basic.Jump.performed += _ => ApplyJumpForce();
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

    public void ApplyJumpForce()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
