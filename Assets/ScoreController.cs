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

    int startingScore = 0;
    int stuntPoints = 100;
    int currentScore = 0;
    string finalTime = "None";

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
    }

    private void Start()
    {
        currentScore = startingScore;
        updateScoreEvent?.Invoke(currentScore);
    }

    public void AddStuntScore()
    {
        currentScore += stuntPoints;
        updateScoreEvent?.Invoke(currentScore);
    }

    public void ResetScore()
    {
        currentScore = startingScore;
        updateScoreEvent?.Invoke(currentScore);
    }

    public void LevelSkip()
    {
        currentScore = 0;
        finalTime = "Skipped";
        SaveScore();
    }

    public void LevelComplete()
    {
        SaveScore();
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "Score", currentScore);
        PlayerPrefs.SetString(SceneManager.GetActiveScene().name + "Time", finalTime);

    }
}
