using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.Events;
using UnityEngine.Audio;

public class BeatController : MonoBehaviour
{
    // Singleton Setup
    private static BeatController _instance;
    public static BeatController Instance { get { return _instance; } }

    public SongData currentSongData;
    public BeatTrackSpriteController beatTrackSpriteController;

    // Events
    public event Action environmentEvent;
    public event Action playerInputEvent;
    public event Action hazardEvent;
    public event Action<int> beatEvent;
    public event Action playbackRestartEvent;

    AudioSource songSource;
    BasicMoveset controls;

    //bool invokingEvents = true;
    BeatEvent[] beatEvents;
    float secondsBetweenBeats;
    Coroutine beatEventInvoker;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(_instance.gameObject);
            _instance = this;
        }
        else
        {
            _instance = this;
        }

        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => RestartCurrentTrack(true);
        controls.Debug.PlayRecording.performed += _ => RestartCurrentTrack(false);
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
        songSource = this.GetComponent<AudioSource>();
        songSource.clip = currentSongData.beatsOnlyClip;
        songSource.Play();
        beatEvents = currentSongData.beatEvents;
        beatTrackSpriteController?.SetBeatSprites(beatEvents);
        secondsBetweenBeats = songSource.clip.length / 16f;
        StartCoroutine(SongStartDelay());
    }

    public void RestartCurrentTrack(bool beatsOnly)
    {
        songSource.Stop();
        //playbackRestartEvent?.Invoke();
        this.StopCoroutine(beatEventInvoker);
        if (beatsOnly)
            songSource.clip = currentSongData.beatsOnlyClip;
        else
            songSource.clip = currentSongData.fullAudioClip;
        songSource.Play();
        beatEventInvoker = StartCoroutine(BeatEventInvoker());
    }

    public IEnumerator BeatEventInvoker()
    {
        BeatEvent nextEvent;
        int curDiv = 0, newDiv;

        while (true)
        {
            newDiv = GetSongPositionInt();

            while (curDiv != newDiv)
            {
                nextEvent = beatEvents[curDiv];
                beatEvent?.Invoke(curDiv);
                switch (nextEvent)
                {
                    case BeatEvent.None:
                        break;
                    case BeatEvent.Hazard:
                        hazardEvent?.Invoke();
                        break;
                    case BeatEvent.PlayerInput:
                        playerInputEvent?.Invoke();
                        break;
                    case BeatEvent.Environment:
                        environmentEvent?.Invoke();
                        break;
                }
                curDiv += 1;
                if (curDiv >= 16)
                    curDiv = 0;
                yield return null;
            }
            yield return null;
        }
    }

    private int GetSongPositionInt()
    {
        //int currentDivision = (int) Mathf.Floor(songSource.time / secondsBetweenBeats);
        int currentDivision = (int) Mathf.Floor(InputCalibratedSourceTime() / secondsBetweenBeats);
        return currentDivision;
    }

    private float InputCalibratedSourceTime()
    {
        float calibratedTime = songSource.time + (SettingsController.Instance.InputCalibrationValue / 20f);

        if (calibratedTime < 0)
        {
            float amountLessThanZero = calibratedTime;
            calibratedTime = songSource.clip.length + amountLessThanZero;
        }
        else if (calibratedTime > songSource.clip.length)
        {
            float amountGreaterThanLength = calibratedTime - songSource.clip.length;
            calibratedTime = amountGreaterThanLength;
        }
        return calibratedTime;
    }

    public void RestartRequest()
    {
        playbackRestartEvent?.Invoke();
        RestartCurrentTrack(false);
    }

    public IEnumerator SongStartDelay()
    {
        yield return new WaitForEndOfFrame();
        beatEventInvoker = StartCoroutine(BeatEventInvoker());
    }
}

public enum BeatEvent
{
    None,
    PlayerInput,
    Hazard,
    Environment
}