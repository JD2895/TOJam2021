using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehavior : MonoBehaviour
{
    public GameObject cannonprojectilePrefab;

    private void OnEnable()
    {
        BeatController.Instance.fireCannonEvent += FireCannon;
    }

    private void OnDisable()
    {
        BeatController.Instance.fireCannonEvent -= FireCannon;
    }

    private void FireCannon()
    {
        Quaternion startingRotation = Quaternion.FromToRotation(Vector3.up, (this.transform.right * -1f));
        GameObject projectile = Instantiate(cannonprojectilePrefab, this.transform.position, startingRotation);
    }
}
