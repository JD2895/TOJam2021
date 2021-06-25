using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordingTimerController : MonoBehaviour
{
    BasicMoveset controls;
    float recordingTime;
    float recordedTime;
    bool countingUp = true;
    public TextMeshProUGUI recordingTimerText;
    public Color countingUpColor;
    public Color countingDownColor;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => StartCountingUp();
        controls.Debug.PlayRecording.performed += _ => StartCountingDown();
    }

    private void OnEnable()
    {
        controls.Enable();
        BeatController.Instance.playbackRestartEvent += StartCountingDown;
    }

    private void OnDisable()
    {
        controls.Disable();
        BeatController.Instance.playbackRestartEvent -= StartCountingDown;
    }

    void Start()
    {
        countingUp = true;
        recordingTimerText.color = countingUpColor;
    }

    void Update()
    {
        if (countingUp)
        {
            recordingTime += Time.deltaTime;
            recordedTime = recordingTime;
        }
        else
        {
            if (recordingTime > 0)
                recordingTime -= Time.deltaTime;
            else
                recordingTime = 0;
        }
        recordingTimerText.text = Mathf.FloorToInt(recordingTime).ToString();
    }

    public void StartCountingUp()
    {
        recordingTimerText.color = countingUpColor;
        recordingTime = 0f;
        countingUp = true;
    }

    public void StartCountingDown()
    {
        recordingTime = recordedTime;
        recordingTimerText.color = countingDownColor;
        countingUp = false;
    }

    public float GetRecordedTime()
    {
        return recordedTime;
    }
}
