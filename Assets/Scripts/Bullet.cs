using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletLifetime = 5.0f;

    [Header("Effects")]
    [SerializeField] AudioClip damageSound;
    [SerializeField] GameObject damageParticles;
    /*
    [SerializeField] AudioClip bulletCollideSound;
    [SerializeField] GameObject bulletCollideParticles;
    */
    private void Start()
    {
        StartCoroutine(DestoryBulletAfterTime(gameObject, bulletLifetime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(damageParticles != null)
        {
            GameObject tempDamageParticles = Instantiate(damageParticles, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(tempDamageParticles, 2f);
        }
        if(damageSound != null)
        {
            AudioHelper.PlayClip2D(damageSound, 1f);
        }
        other.gameObject.SetActive(false);
        Destroy(gameObject);

        // add diff effects for hitting bullets
    }

    private IEnumerator DestoryBulletAfterTime(GameObject bullet, float lifetime)
    {
        yield return new WaitForSeconds(lifetime);

        Destroy(bullet);
    }
}
