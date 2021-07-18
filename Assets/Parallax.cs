using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject player;
    public float parallaxMult;
    float maxDifference = 9;

    Vector3 startPos;

    private void Awake()
    {
        startPos = this.transform.position;
    }

    void Update()
    {
        Vector3 newPos = Vector3.zero;
        Vector3 difference = player.transform.position - startPos;
        if (difference.magnitude >= maxDifference)
        {
            difference = difference.normalized * maxDifference;
        }
        newPos = difference * parallaxMult;
        this.transform.position = newPos;
    }
}
