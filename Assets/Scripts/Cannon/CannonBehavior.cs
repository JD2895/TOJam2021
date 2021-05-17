using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour
{
    public GameObject cannonprojectilePrefab;
    public Transform projectileSpawnPoint;
    BasicMoveset controls;
    bool recordingState = true;

    public Sprite[] cannonBallSprites;

    private void Awake()
    {
        controls = new BasicMoveset();
        controls.Debug.StartRecording.performed += _ => SetRecordingState(true);
        controls.Debug.PlayRecording.performed += _ => SetRecordingState(false);
    }

    private void Start()
    {
        recordingState = true;
    }

    private void OnEnable()
    {
        controls.Enable();
        BeatController.Instance.fireCannonEvent += FireCannon;
    }

    private void OnDisable()
    {
        controls.Disable();
        BeatController.Instance.fireCannonEvent -= FireCannon;
    }

    private void FireCannon()
    {
        Quaternion startingRotation = Quaternion.FromToRotation(Vector3.up, (this.transform.right * -1f));
        GameObject projectile = Instantiate(cannonprojectilePrefab, projectileSpawnPoint.position, startingRotation);
        if (recordingState)
            projectile.GetComponent<CannonProjectileBehavior>().SetSprite(cannonBallSprites[0]);
        else
            projectile.GetComponent<CannonProjectileBehavior>().SetSprite(cannonBallSprites[1]);
    }

    private void SetRecordingState(bool toSet)
    {
        recordingState = toSet;
    }
}
