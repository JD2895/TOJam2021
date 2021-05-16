﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SettingsController : MonoBehaviour
{
    // Singleton (+ other) Setup
    private static SettingsController _instance;
    public static SettingsController Instance { get { return _instance; } }
    BasicMoveset controls;
    bool menuEnabled = false;
    float returningTimescale = 1f;

    public GameObject menuObject;
    public event Action levelFinishEvent;

    // Hazard Collision
    bool _hazardCollisionEnabled = true;
    public bool HazardCollisionEnabled { get { return _hazardCollisionEnabled; } }

    // Level Changing
    public List<string> listOfLevels = new List<string>();

    // Volume
    static float volumeLevel = 0.5f;

    // Input Calibration
    static float _inputCalibration = 0.0f;
    public float InputCalibrationValue { get { return _inputCalibration; } }

    // UI
    public Toggle hazardToggle;
    public Slider volumeSlider;
    public Slider inputCalSlider;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        volumeSlider.value = volumeLevel;
        inputCalSlider.value = _inputCalibration;
        hazardToggle.isOn = _hazardCollisionEnabled;

        controls = new BasicMoveset();
        controls.Debug.Menu.performed += _ => ToggleMenu();
        menuObject.SetActive(menuEnabled);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void ChangeHazardCollisionToggle(bool toSet)
    {
        _hazardCollisionEnabled = toSet;
        hazardToggle.isOn = _hazardCollisionEnabled;
    }

    public void ChangeVolumeSlider(float toSet)
    {
        volumeLevel = toSet;
        volumeSlider.value = volumeLevel;
    }

    public void ChangeInputCalibrationSlider(float toSet)
    {
        _inputCalibration = toSet;
        inputCalSlider.value = _inputCalibration;
    }

    public void ToggleMenu()
    {
        menuEnabled = !menuEnabled;
        menuObject.SetActive(menuEnabled);

        volumeSlider.value = volumeLevel;
        inputCalSlider.value = _inputCalibration;
        hazardToggle.isOn = _hazardCollisionEnabled;

        // Pause
        Time.timeScale = menuEnabled ? 0f : returningTimescale;
    }

    public void RestartLevel()
    {
        StartCoroutine(LoadOutTransition(SceneManager.GetActiveScene().name));
    }

    IEnumerator LoadOutTransition(string levelName)
    {
        //transition.SetTrigger("TransitionOut");

        //yield return new WaitForSeconds(transitionTime);
        yield return null;

        SceneManager.LoadScene(levelName);
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadOutTransition(levelName));
    }

    public void NextLevel()
    {
        Time.timeScale = returningTimescale;
        int nextIndex = listOfLevels.IndexOf(SceneManager.GetActiveScene().name) + 1;
        if (nextIndex >= listOfLevels.Count - 1)
            nextIndex = 0;
        StartCoroutine(LoadOutTransition(listOfLevels[nextIndex]));
    }

    public void PrevLevel()
    {
        Time.timeScale = returningTimescale;
        int prevIndex = listOfLevels.IndexOf(SceneManager.GetActiveScene().name) - 1;
        if (prevIndex <= 0)
            prevIndex = 0;
        StartCoroutine(LoadOutTransition(listOfLevels[prevIndex]));
    }

    public void TriggerLevelFinish()
    {
        levelFinishEvent?.Invoke();
    }

    public void Exit()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
