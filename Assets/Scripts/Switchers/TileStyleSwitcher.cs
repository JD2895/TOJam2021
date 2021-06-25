using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStyleSwitcher : MonoBehaviour
{
    public GameObject fullTilemap;
    public GameObject bwTileMap;

    BasicMoveset controls;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => ChangeTileStyle(true);
        controls.Debug.PlayRecording.performed += _ => ChangeTileStyle(false);
    }

    private void Start()
    {
        ChangeTileStyle(true);
    }

    private void OnEnable()
    {
        controls.Enable();
        BeatController.Instance.playbackRestartEvent += () => { ChangeTileStyle(false); };
    }

    private void OnDisable()
    {
        controls.Disable();
        BeatController.Instance.playbackRestartEvent -= () => { ChangeTileStyle(false); };
    }

    private void ChangeTileStyle(bool isRecording)
    {
        bwTileMap.SetActive(isRecording);
        fullTilemap.SetActive(!isRecording);
    }
}
