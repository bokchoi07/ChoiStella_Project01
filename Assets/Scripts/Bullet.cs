using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletLifetime = 5.0f;

    private void Start()
    {
        StartCoroutine(DestoryBulletAfterTime(gameObject, bulletLifetime));
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private IEnumerator DestoryBulletAfterTime(GameObject bullet, float lifetime)
    {
        yield return new WaitForSeconds(lifetime);

        Destroy(bullet);
    }
}
