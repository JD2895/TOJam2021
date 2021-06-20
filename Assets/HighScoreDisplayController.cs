using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreDisplayController : MonoBehaviour
{
    public GameObject highScoreContainer;
    public GameObject scoreDisplayPrefab;
    public float delayBetweenScores = 0.5f;
    public List<string> levelsToIgnore = new List<string>();
    
    GameObject scoreObjectRef;
    LevelScoreObjectHelper scoreObjectHelper;
    List<string> levelNames;

    void Start()
    {
        levelNames = SettingsController.Instance.listOfLevels;
        StartCoroutine(DisplayeScores());
    }

    IEnumerator DisplayeScores()
    {
        foreach (string levelName in levelNames)
        {
            if (levelsToIgnore.Contains(levelName))
                continue;
            yield return new WaitForSeconds(delayBetweenScores);
            scoreObjectRef = GameObject.Instantiate(scoreDisplayPrefab, highScoreContainer.transform);
            scoreObjectHelper = scoreObjectRef.GetComponent<LevelScoreObjectHelper>();

            scoreObjectHelper.SetObjectInfo(levelName, PlayerPrefs.GetString(levelName + "Score", "Skipped"));
            scoreObjectHelper.SetTextObjectsActive();
        }
        yield return null;
    }
}
