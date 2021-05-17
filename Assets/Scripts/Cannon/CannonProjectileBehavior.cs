using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectileBehavior : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    BasicMoveset controls;
    public SpriteRenderer sprRend;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => Destroy(this.gameObject);
        controls.Debug.PlayRecording.performed += _ => Destroy(this.gameObject);
    }

    private void OnEnable()
    {
        controls.Enable();
        BeatController.Instance.playbackRestartEvent += ToDestroy;
    }

    private void OnDisable()
    {
        controls.Disable();
        BeatController.Instance.playbackRestartEvent -= ToDestroy;
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(this.transform.position + (this.transform.up * speed * Time.fixedDeltaTime));
    }

    public void ToDestroy()
    {
        Destroy(this.gameObject);
    }

    public void SetSprite(Sprite toSet)
    {
        sprRend.sprite = toSet;
    }
}
