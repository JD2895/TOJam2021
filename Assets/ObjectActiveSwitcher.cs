using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActiveSwitcher : MonoBehaviour
{
    public GameObject fullObject;
    public GameObject bwObject;

    BasicMoveset controls;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => ChangeObjectActive(true);
        controls.Debug.PlayRecording.performed += _ => ChangeObjectActive(false);
    }

    private void Start()
    {
        ChangeObjectActive(true);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void ChangeObjectActive(bool isRecording)
    {
        fullObject.SetActive(!isRecording);
        bwObject.SetActive(isRecording);
    }
}
