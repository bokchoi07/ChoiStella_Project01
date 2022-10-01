using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    int fireCount = 0;
    float lastShotTime;

    //Health bossHealth;

    //public Transform player;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public Transform missileSpawn;
    public GameObject missilePrefab;

    [SerializeField] float bulletForce = 25.0f;
    [SerializeField] float fireRate = 1.5f;
    [SerializeField] AudioClip bulletShootSFX;
    [SerializeField] AudioClip missileShootSFX;
    
    private void Update()
    {
        if(Time.time - lastShotTime >= fireRate)
        {
            FireBullets();
        }
    }

    public void FireBullets()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletSpawn.forward * bulletForce, ForceMode.Impulse);

        AudioHelper.PlayClip2D(bulletShootSFX, 1f);

        lastShotTime = Time.time;
        fireCount++;

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
        AudioHelper.PlayClip2D(missileShootSFX, 1f);
    }
}
