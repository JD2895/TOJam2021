using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectileBehavior : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    BasicMoveset controls;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => Destroy(this.gameObject);
        controls.Debug.PlayRecording.performed += _ => Destroy(this.gameObject);
    }

    private void OnEnable()
    {
        controls.Enable();
        BeatController.Instance.playbackRestartEvent += () => { Destroy(this.gameObject); };
    }

    private void OnDisable()
    {
        controls.Disable();
        BeatController.Instance.playbackRestartEvent -= () => { Destroy(this.gameObject); };
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 10f);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(this.transform.position + (this.transform.up * speed * Time.fixedDeltaTime));
    }
}
