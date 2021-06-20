using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class LevelCompleteController : MonoBehaviour
{
    public GameObject levelFinishPanel;
    public TextMeshProUGUI stuntScoreText;
    public TextMeshProUGUI timeTakenText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;
    public float waitBeforeTicking = 0.75f;
    public float tickingReductionFactor = 10f;

    int stuntScore;
    int actualFinalScore;
    string highScoreValueText;
    int highScoreValue;
    BasicMoveset controls;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Debug.PlayRecording.performed += _ => HideLevelCOmpeltePanel();
        controls.Debug.StartRecording.performed += _ => HideLevelCOmpeltePanel();
    }

    private void OnEnable()
    {
        controls.Enable();
        SettingsController.Instance.levelFinishEvent += SetLevelFinishPanelActive;
        BeatController.Instance.playbackRestartEvent += HideLevelCOmpeltePanel;
    }

    private void OnDisable()
    {
        controls.Disable();
        SettingsController.Instance.levelFinishEvent -= SetLevelFinishPanelActive;
        BeatController.Instance.playbackRestartEvent -= HideLevelCOmpeltePanel;
    }

    private void Start()
    {
        levelFinishPanel.SetActive(false);
    }

    private void HideLevelCOmpeltePanel()
    {
        levelFinishPanel.SetActive(false);
    }

    private void SetLevelFinishPanelActive()
    {
        stuntScoreText.text = ScoreController.Instance.StuntScore.ToString();
        stuntScore = ScoreController.Instance.StuntScore;
        timeTakenText.text = ScoreController.Instance.TimeTaken.ToString();
        finalScoreText.text = ScoreController.Instance.StuntScore.ToString();   // Intentionally getting stunt score for animation
        actualFinalScore = ScoreController.Instance.FinalScore;
        string highScoreValueText = ScoreController.Instance.GetHighScore();
        if (highScoreValueText == "Skipped")
            highScoreText.text = "0";
        else
        {
            highScoreText.text = highScoreValueText;
            highScoreValue = Int16.Parse(highScoreValueText);
        }

        levelFinishPanel.SetActive(true);
        if (actualFinalScore == 999)
        {
            StartCoroutine(TickUpToMax());
        }
        else
        {
            StartCoroutine(FinalScoreTicking());
        }
    }

    private IEnumerator FinalScoreTicking()
    {
        yield return new WaitForSeconds(waitBeforeTicking);
        int displayedFinalScore = stuntScore;
        while (displayedFinalScore >= actualFinalScore)
        {
            displayedFinalScore -= (int)Mathf.Ceil(tickingReductionFactor * Time.deltaTime);
            if (displayedFinalScore < actualFinalScore)
            {
                displayedFinalScore = actualFinalScore;
            }
            finalScoreText.text = displayedFinalScore.ToString();
            yield return null;
        }

        if (actualFinalScore > highScoreValue)
        {
            Debug.Log("in here");
            yield return new WaitForSeconds(waitBeforeTicking * 0.5f);
            highScoreText.text = actualFinalScore.ToString();
        }
    }

    private IEnumerator TickUpToMax()
    {
        yield return new WaitForSeconds(waitBeforeTicking);
        int displayedFinalScore = stuntScore;
        while (displayedFinalScore <= actualFinalScore)
        {
            displayedFinalScore += (int)Mathf.Ceil(tickingReductionFactor * 1.5f * Time.deltaTime);
            if (displayedFinalScore > actualFinalScore)
            {
                displayedFinalScore = actualFinalScore;
            }
            finalScoreText.text = displayedFinalScore.ToString();
            yield return null;
        }

        if (actualFinalScore > highScoreValue)
        {
            yield return new WaitForSeconds(waitBeforeTicking * 0.5f);
            highScoreText.text = actualFinalScore.ToString();
        }
    }
}
