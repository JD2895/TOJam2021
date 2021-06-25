using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelScoreObjectHelper : MonoBehaviour
{
    public GameObject levelNameObject;
    public TextMeshProUGUI levelName;
    public GameObject levelScoreObject;
    public TextMeshProUGUI levelScore;

    public void SetObjectInfo(string newName, string newScore)
    {
        levelName.text = newName;
        levelScore.text = newScore;
    }

    public void SetTextObjectsActive()
    {
        levelNameObject.SetActive(true);
        levelScoreObject.SetActive(true);
    }
}
