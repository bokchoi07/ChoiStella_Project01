using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    [SerializeField] int ammo = 20;
    [SerializeField] float bulletForce = 15.0f;

    [Header("Effects")]
    [SerializeField] GameObject shootingParticlesPrefab;
    [SerializeField] AudioClip shootingSound;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ammo > 0)
        {
            FireBullet();
            //Debug.Log("ammo count: " + ammo);
        }
    }

    public void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletSpawn.forward * bulletForce, ForceMode.Impulse);
        ammo -= 1;
        /*if (shootingParticlesPrefab != null)
        {
            shootingParticlesPrefab.Play();
        }*/
        if (shootingParticlesPrefab != null)
        {
            GameObject tempShootingParticles = Instantiate(shootingParticlesPrefab, bulletSpawn.position, Quaternion.identity);
            Destroy(tempShootingParticles, 2f);
        }

        if (shootingSound != null)
        {
            AudioHelper.PlayClip2D(shootingSound, 1f);
        }
    }
}
