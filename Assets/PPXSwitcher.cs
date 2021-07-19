using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PPXSwitcher : MonoBehaviour
{
    Volume volume;
    ChromaticAberration chromaticAberration;
    Vignette vignette;
    FilmGrain filmGrain;
    public AnimationCurve curve;

    public bool recordingEnabled = true;
    bool currentState = true;
    BasicMoveset controls;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => StartCoroutine(ToRecording());
        controls.Debug.PlayRecording.performed += _ => StartCoroutine(ToPlayback());
        currentState = recordingEnabled;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        Volume volume = gameObject.GetComponent<Volume>();
        ChromaticAberration tmpCA;
        Vignette tempV;
        FilmGrain tempFG;

        if (volume.profile.TryGet<ChromaticAberration>(out tmpCA))
        {
            chromaticAberration = tmpCA;
        }
        if (volume.profile.TryGet<Vignette>(out tempV))
        {
            vignette = tempV;
        }
        if (volume.profile.TryGet<FilmGrain>(out tempFG))
        {
            filmGrain = tempFG;
        }

        StartCoroutine(ToRecording());
    }

    IEnumerator ToRecording()
    {
        vignette.active = true;

        for(float t = 0f; t < 1f; t += Time.deltaTime)
        {
            chromaticAberration.intensity.value = 1f - curve.Evaluate(t);
            filmGrain.intensity.value = 1f - curve.Evaluate(t);
            yield return null;
        }
    }

    IEnumerator ToPlayback()
    {
        vignette.active = false;

        for (float t = 0f; t < 1f; t += Time.deltaTime)
        {
            chromaticAberration.intensity.value = 1f - curve.Evaluate(t);
            filmGrain.intensity.value = 1f - curve.Evaluate(t);
            yield return null;
        }
    }
}
