using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    // Singleton Setup
    private static ScoreController _instance;
    public static ScoreController Instance { get { return _instance; } }

    // Events
    public event Action<int> updateScoreEvent;

    BasicMoveset controls;
    int startingScore = 0;
    string previousHighScore;
    int stuntPoints = 100;
    int _stuntScore = 0;
    public int StuntScore
    {
        get { return _stuntScore; }
    }
    int _timeTaken = 99999;
    public int TimeTaken
    {
        get { return _timeTaken; }
    }
    int _finalScore = 0;
    public int FinalScore
    {
        get { return _finalScore; }
    }

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
        controls.Debug.PlayRecording.performed += _ => ResetScore();
    }

    private void OnEnable()
    {
        controls.Enable();
        BeatController.Instance.playbackRestartEvent += ResetScore;
    }

    private void OnDisable()
    {
        controls.Disable();
        BeatController.Instance.playbackRestartEvent -= ResetScore;
    }

    private void Start()
    {
        _stuntScore = startingScore;
        updateScoreEvent?.Invoke(_stuntScore);
    }

    public void AddStuntScore()
    {
        _stuntScore += stuntPoints;
        updateScoreEvent?.Invoke(_stuntScore);
    }

    public void SetTimeTaken(int newTimeTaken)
    {
        _timeTaken = newTimeTaken;
    }

    public void ResetScore()
    {
        _stuntScore = startingScore;
        updateScoreEvent?.Invoke(_stuntScore);
    }

    public string GetHighScore()
    {
        return previousHighScore;
    }

    public void LevelSkip()
    {
        _stuntScore = 0;
        _timeTaken = 99999;
        SaveScore();
    }

    public void LevelComplete()
    {
        if (_stuntScore == 0)
            _finalScore = 0;
        else
        {
            if (_timeTaken == 0)
            {
                _finalScore = 999;
            }
            else
                _finalScore = _stuntScore / _timeTaken;
        }
        SaveScore();
    }

    void SaveScore()
    {
        string levelScore = PlayerPrefs.GetString(SceneManager.GetActiveScene().name + "Score", "Skipped");     // Only set the score for this level to 'Skipped' if the level was skipped AND there was no better score
        previousHighScore = levelScore;
        if (_timeTaken >= 99999)
            return;
        if (levelScore == "Skipped") 
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "Score", _finalScore.ToString());
        else if (Int16.Parse(levelScore) < _finalScore)
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "Score", _finalScore.ToString());
    }
}
