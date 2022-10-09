using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    [SerializeField] public int ammo = 20;
    [SerializeField] public int maxAmmo = 20;
    [SerializeField] float bulletForce = 15.0f;

    [Header("Effects")]
    [SerializeField] GameObject shootingParticlesPrefab;
    [SerializeField] AudioClip shootingSound;
    [SerializeField] AudioClip reloadSFX;

    public event Action<int> AmmoChange;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ammo > 0)
        {
            FireBullet();
            AmmoChange?.Invoke(ammo);
        }
        if (Input.GetKeyDown(KeyCode.R) && ammo == 0)
        {
            ammo = maxAmmo;
            AmmoChange?.Invoke(ammo);
            AudioHelper.PlayClip2D(reloadSFX, 1.0f);
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
