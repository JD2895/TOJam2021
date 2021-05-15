using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificialGravity : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 newVelocity;

    public float gravityAcceleration;
    public float gravityMax;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        newVelocity = rb.velocity;
        
        if (newVelocity.y > (gravityMax * -1f))
        {
            newVelocity.y -= gravityAcceleration * Time.fixedDeltaTime;
        }

        rb.velocity = newVelocity;
    }
}
