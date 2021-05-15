using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class BeatController : MonoBehaviour
{
    // Singleton Setup
    private static BeatController _instance;
    public static BeatController Instance { get { return _instance; } }

    public event Action jumpPadEvent;
    public SongData currentSongData;
    public float startOffset;

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
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => RestartCurrentTrack();
        controls.Debug.PlayRecording.performed += _ => RestartCurrentTrack();
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
        secondsBetweenBeats = songSource.clip.length / 16f;
        beatEventInvoker = StartCoroutine(BeatEventInvoker());
    }

    public void RestartCurrentTrack()
    {
        songSource.Stop();
        this.StopCoroutine(beatEventInvoker);
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
                switch (nextEvent)
                {
                    case BeatEvent.None:
                        break;
                    case BeatEvent.JumpPad:
                        jumpPadEvent.Invoke();
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
        int currentDivision = (int) Mathf.Floor(songSource.time / secondsBetweenBeats);
        return currentDivision;
    }
}

public enum BeatEvent
{
    None,
    PlayerInput,
    FireCannon,
    JumpPad
}