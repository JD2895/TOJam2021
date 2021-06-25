using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        ScoreController.Instance.updateScoreEvent += UpdateScoreText;
    }

    private void OnDisable()
    {
        ScoreController.Instance.updateScoreEvent -= UpdateScoreText;
    }

    void UpdateScoreText(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
}
