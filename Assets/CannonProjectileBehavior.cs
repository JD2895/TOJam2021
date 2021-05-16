using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectileBehavior : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(this.transform.position + (this.transform.up * speed * Time.fixedDeltaTime));
    }
}
