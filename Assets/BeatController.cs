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
    float timeOfLastBeat;

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
        timeOfLastBeat = Time.time + startOffset;
        beatEvents = currentSongData.beatEvents;
        secondsBetweenBeats = songSource.clip.length / 16f;
        StartCoroutine(BeatEventInvoker());
    }

    public void RestartCurrentTrack()
    {
        songSource.Stop();
        songSource.Play();
    }

    public IEnumerator BeatEventInvoker()
    {
        int eventIterator = 1; // Skip first event to avoid race issues
        BeatEvent nextEvent = beatEvents[eventIterator];

        while (true)
        {
            if (Time.time - timeOfLastBeat >= secondsBetweenBeats)
            {
                switch (nextEvent)
                {
                    case BeatEvent.None:
                        break;
                    case BeatEvent.JumpPad:
                        jumpPadEvent.Invoke();
                        break;
                }

                eventIterator += 1;
                if (eventIterator >= beatEvents.Length)
                    eventIterator = 0;
                nextEvent = beatEvents[eventIterator];

                timeOfLastBeat = Time.time;
            }
            yield return null;
        }
    }
}

public enum BeatEvent
{
    None,
    PlayerInput,
    FireCannon,
    JumpPad
}