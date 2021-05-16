using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteController : MonoBehaviour
{
    public GameObject levelFinishPanel;

    private void OnEnable()
    {
        SettingsController.Instance.levelFinishEvent += SetLevelFinishPanelActive;
    }

    private void OnDisable()
    {
        SettingsController.Instance.levelFinishEvent -= SetLevelFinishPanelActive;
    }

    private void Start()
    {
        levelFinishPanel.SetActive(false);
    }

    private void SetLevelFinishPanelActive()
    {
        levelFinishPanel.SetActive(true);
    }
}
