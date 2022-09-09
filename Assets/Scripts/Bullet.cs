using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletLifetime = 5.0f;
    [SerializeField] int bulletDamage = 2;

    [Header("Effects")]
    [SerializeField] AudioClip damageSound;
    [SerializeField] GameObject damageParticles;
    
    [SerializeField] AudioClip killSound;
    [SerializeField] GameObject killParticles;
    
    private void Start()
    {
        StartCoroutine(DestoryBulletAfterTime(gameObject, bulletLifetime));
    }

    private void OnTriggerEnter(Collider other)
    { 
        // if collider is damageable aka has health
        if (other.gameObject.GetComponent<IDamageable>() != null)
        {
            Health healthScript = other.gameObject.GetComponent<Health>();
            healthScript.TakeDamage(bulletDamage);

            // when object has no health, do kill effects not damage
            if (healthScript.getHealth() <= 0)
            {
                if (killParticles != null)
                {
                    GameObject tempKillParticles = Instantiate(killParticles, gameObject.transform.position, gameObject.transform.rotation);
                    Destroy(tempKillParticles, 2f);
                }
                if (killSound != null)
                {
                    AudioHelper.PlayClip2D(killSound, 1f);
                }
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            // damage effects for when there is still health left
            else
            {
                if (damageParticles != null)
                {
                    GameObject tempDamageParticles = Instantiate(damageParticles, gameObject.transform.position, gameObject.transform.rotation);
                    Destroy(tempDamageParticles, 2f);
                }
                if (damageSound != null)
                {
                    AudioHelper.PlayClip2D(damageSound, 1f);
                }
                Destroy(gameObject);
            }
        }
        else // if collider has no IDamageable/health.cs - instant kill/destroy ex. walls, bullets
        {
            Debug.Log("not damageable");
            //Color colliderColor = other.gameObject.GetComponent<Material>().color;

            if (killParticles != null)
            {
                //ParticleSystem.MainModule ma = killParticles.GetComponent<ParticleSystem>().main;
                //ma.startColor = colliderColor;
                GameObject tempKillParticles = Instantiate(killParticles, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(tempKillParticles, 2f);
            }
            if (killSound != null)
            {
                AudioHelper.PlayClip2D(killSound, 1f);
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private IEnumerator DestoryBulletAfterTime(GameObject bullet, float lifetime)
    {
        yield return new WaitForSeconds(lifetime);

        Destroy(bullet);
    }
}
