using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    int fireCount = 0;
    float lastShotTime;
    MeshRenderer meshRenderer;
    Color originalColor;

    //Health bossHealth;

    //public Transform player;
    public Transform cannonballSpawn;
    public GameObject cannonballPrefab;
    public Transform missileSpawn;
    public GameObject missilePrefab;

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
    }

    private void Update()
    {
        if(Time.time - lastShotTime >= fireRate)
        {
            FireCannonball();
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
        fireCount++;

        if(fireCount == 2)
        {
            FlashStart();
            AudioHelper.PlayClip2D(warningSFX, .1f);
        }

        if(fireCount == 3)
        {
            FireMissile();
            fireCount = 0;
        }
    }

    public void FireMissile()
    {
        // shoot "missile" like projectile targeted at player
        GameObject missile = Instantiate(missilePrefab, missileSpawn.position, missileSpawn.rotation);
        GameObject tempMissileParticles = Instantiate(missileParticles, missileSpawn.position, missileSpawn.rotation);
        AudioHelper.PlayClip2D(missileShootSFX, 1f);
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
