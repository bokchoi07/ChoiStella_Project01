using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] int missileDamage = 2;

    [Header("Effects")]
    [SerializeField] AudioClip damageSound;
    [SerializeField] GameObject damageParticles;

    [SerializeField] AudioClip killSound;
    [SerializeField] GameObject killParticles;

    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        transform.up = player.transform.position - transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IDamageable>() != null)
        {
            Health healthScript = other.gameObject.GetComponent<Health>();
            healthScript.TakeDamage(missileDamage);

            // when object has no health, do kill effects not damage
            if (healthScript.GetHealth() <= 0)
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
}
