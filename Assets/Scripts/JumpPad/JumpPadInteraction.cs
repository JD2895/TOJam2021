using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadInteraction : MonoBehaviour
{
    Rigidbody2D rb;

    public float castCheckDistance;
    public float jumpPadForce;

    private void OnEnable()
    {
        BeatController.Instance.jumpPadEvent += CheckForJumpPad;
    }

    private void OnDisable()
    {
        BeatController.Instance.jumpPadEvent -= CheckForJumpPad;
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void CheckForJumpPad()
    {
        //Debug.Log("Checking for jump pad");
        RaycastHit2D[] castResults = new RaycastHit2D[2];
        int numberHit = rb.Cast(Vector2.down, castResults, castCheckDistance);
        if(numberHit > 0)
        {
            for(int i = 0; i < numberHit; i++)
            {
                if (castResults[i].collider.CompareTag("Jump Pad"))
                    ActivateJumpPadEffect();
            }
        }
    }

    private void ActivateJumpPadEffect()
    {
        rb.AddForce((Vector2.up * jumpPadForce), ForceMode2D.Impulse);
    }
}
