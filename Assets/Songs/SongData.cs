using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "New Song Data", menuName = "Song Data")]
public class SongData : ScriptableObject
{
    public AudioClip beatsOnlyClip;
    public AudioClip fullAudioClip;
    public BeatEvent[] beatEvents = new BeatEvent[] { };
}
