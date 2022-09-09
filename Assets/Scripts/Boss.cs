using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    int fireCount = 0;
    
    float lastShotTime;
    //bool isFiring = false;
    Health bossHealth;

    public Transform player;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    [SerializeField] float bulletForce = 25.0f;
    [SerializeField] float fireRate = 1.5f;
    
    private void Start()
    {
        bossHealth = gameObject.GetComponent<Health>();
    }
    private void Update()
    {
        if(Time.time - lastShotTime >= fireRate)
        {
            FireBullets();
        }
    }

    public void Move()
    {
        // patrol points
    }

    public void FireBullets()
    {
        // shoot 3 consecutive bullets

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletSpawn.forward * bulletForce, ForceMode.Impulse);

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

        
    }

    
}
