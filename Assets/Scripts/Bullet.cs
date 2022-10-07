using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectiles
{
    private void Start()
    {
        StartCoroutine(DestoryAfterTime(gameObject, 5.0f));
    }
}
