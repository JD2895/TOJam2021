using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementRecorder : MonoBehaviour
{
    public GameObject playerObject;

    // Controllers
    bool isRecording = false;
    bool isPlayingMoves = false;

    // Setup
    BasicMoveset controls;
    SideMovement sidemoventController;
    Jump jumpController;
    float startTime;
    float recordedTime;
    Vector3 startingPosition;
    List<ActionTime> recordedActions = new List<ActionTime>();

    // Playback
    float playbackStartTime;
    Coroutine playbackRoutine;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Basic.Left.performed += _ => RecordMove(ActionType.StartLeft);
        controls.Basic.Left.canceled += _ => RecordMove(ActionType.EndLeft);
        controls.Basic.Right.performed += _ => RecordMove(ActionType.StartRight);
        controls.Basic.Right.canceled += _ => RecordMove(ActionType.EndRight);
        
        controls.Debug.StartRecording.performed += _ => StartRecording();
        controls.Debug.PlayRecording.performed += _ => PlaybackRecordedMoves();
    }

    private void OnEnable()
    {
        controls.Enable();
        BeatController.Instance.playbackRestartEvent += PlaybackRecordedMoves;
    }

    private void OnDisable()
    {
        controls.Disable();
        BeatController.Instance.playbackRestartEvent -= PlaybackRecordedMoves;
    }

    private void Start()
    {
        if(playerObject == null)
        {
            playerObject = GameObject.Find("Player");
        }

        startTime = Time.time;
        startingPosition = playerObject.transform.position;
        sidemoventController = playerObject.GetComponent<SideMovement>();
        jumpController = playerObject.GetComponent<Jump>();

        StartRecording();
    }

    private void RecordMove(ActionType newAction)
    {
        if (isRecording)
        {
            recordedTime = Time.time - startTime;
            recordedActions.Add(new ActionTime(newAction, recordedTime));
        }
    }

    private void ChangeControlState(bool isRecording)
    {
        sidemoventController?.SetPlayerInControl(isRecording);
        jumpController?.SetPlayerInControl(!isRecording);
    }

    private void PlaybackRecordedMoves()
    {
        Debug.Log("Starting Move Playback");
        ChangeControlState(false);
        isRecording = false;
        playerObject.transform.position = startingPosition;

        if (recordedActions.Count > 0)
        {
            isPlayingMoves = true;
            playbackRoutine = StartCoroutine(PlayingMoves());
        }
        else
        {
            Debug.Log("No moves to play");
        }

    }

    private void StartRecording()
    {
        // Prep
        ClearRecordedMoves(false);
        EndPlayback();
        ChangeControlState(true);

        Debug.Log("Starting Move Recording");
        startTime = Time.time;

        // Player Positioning
        playerObject.transform.position = startingPosition;

        isRecording = true;
    }

    #region Helper Functions
    public IEnumerator PlayingMoves()
    {
        playbackStartTime = Time.time;

        foreach (ActionTime nextMove in recordedActions)
        {
            while (isPlayingMoves)
            {
                if (Time.time - playbackStartTime >= nextMove.time)
                {
                    switch (nextMove.action)
                    {
                        case ActionType.StartLeft:
                            sidemoventController.MoveLeftStart();
                            break;
                        case ActionType.EndLeft:
                            sidemoventController.MoveLeftEnd();
                            break;
                        case ActionType.StartRight:
                            sidemoventController.MoveRightStart();
                            break;
                        case ActionType.EndRight:
                            sidemoventController.MoveRightEnd();
                            break;
                    }
                    break;
                }

                yield return null;
            }
        }

        Debug.Log("Playback Ended");
    }

    private void ClearRecordedMoves(bool stopOtherActions = true)
    {
        Debug.Log("Clearing Recorded Moves");
        if (stopOtherActions)
        {
            StopRecording();
            EndPlayback();
        }
        recordedActions.Clear();
    }

    public void EndPlayback()
    {
        if (isPlayingMoves)
        {
            Debug.Log("Ending playback");
            this.StopCoroutine(playbackRoutine);
            isPlayingMoves = false;
        }
    }

    private void StopRecording()
    {
        if (isRecording)
        {
            Debug.Log("Stopping Recording");
            isRecording = false;
        }
    }
    #endregion

    struct ActionTime
    {
        public ActionTime (ActionType newAction, float newTime)
        {
            action = newAction;
            time = newTime;
        }

        public ActionType action;
        public float time;
    }

    private enum ActionType
    {
        StartLeft,
        EndLeft,
        StartRight,
        EndRight
    }
}
