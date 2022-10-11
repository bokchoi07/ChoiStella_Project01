using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    int fireCount = 1;
    float lastShotTime;
    MeshRenderer meshRenderer;
    Color originalColor;

    public Transform cannonballSpawn;
    public GameObject cannonballPrefab;
    public Transform missileSpawn;
    public GameObject missilePrefab;

    [SerializeField] GameObject player;
    [SerializeField] GameObject boss;
    public bool playerAlive;

    [SerializeField] float bulletForce = 25.0f;
    [SerializeField] float fireRate = 1.5f;
    [SerializeField] AudioClip bulletShootSFX;
    [SerializeField] AudioClip missileShootSFX;
    [SerializeField] AudioClip warningSFX;
    [SerializeField] GameObject cannonballParticles;
    [SerializeField] GameObject missileParticles;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;
        playerAlive = true;
    }

    private void Update()
    {
        if(player != null && player.GetComponent<Health>().GetHealth() <= 0)
        {
            playerAlive = false;
        }

        if(boss.GetComponent<Health>().GetHealth() <= 10)
        {
            fireRate = 1f;
        }

        if (Time.time - lastShotTime >= fireRate && playerAlive)
        {
            if (fireCount == 4)
            {
                FireMissile();
                fireCount = 1;
                Debug.Log("if");
            }
            else
            {
                FireCannonball();
                if (fireCount == 3)
                {
                    FlashStart();
                    AudioHelper.PlayClip2D(warningSFX, .1f);
                }

                fireCount++;
                Debug.Log("else");
            }
        }
    }

    public void FireCannonball()
    {
        GameObject cannonball = Instantiate(cannonballPrefab, cannonballSpawn.position, cannonballSpawn.rotation);
        Rigidbody rb = cannonball.GetComponent<Rigidbody>();
        rb.AddForce(cannonballSpawn.forward * bulletForce, ForceMode.Impulse);

        GameObject tempCannonballParticles = Instantiate(cannonballParticles, cannonballSpawn.position, cannonballSpawn.rotation);
        AudioHelper.PlayClip2D(bulletShootSFX, 1f);

        lastShotTime = Time.time;
    }

    public void FireMissile()
    {
        GameObject missile = Instantiate(missilePrefab, missileSpawn.position, missileSpawn.rotation);
        GameObject tempMissileParticles = Instantiate(missileParticles, missileSpawn.position, missileSpawn.rotation);
        AudioHelper.PlayClip2D(missileShootSFX, 1f);

        lastShotTime = Time.time;
    }

    void FlashStart()
    {
        meshRenderer.material.color = Color.red;
        Invoke("FlashStop", 1.0f);
    }

    void FlashStop()
    {
        meshRenderer.material.color = originalColor;
    }
}
