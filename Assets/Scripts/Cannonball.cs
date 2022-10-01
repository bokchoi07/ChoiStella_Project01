using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : Projectiles
{
    [SerializeField] public float lifetime = 5.0f;

    private void Start()
    {
        StartCoroutine(DestoryAfterTime(gameObject, lifetime));
    }
}
