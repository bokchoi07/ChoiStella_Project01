using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public interface IDamageable
{
    void TakeDamage(int damage);
}

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] int health = 20;
    [SerializeField] int maxHealth = 20;

    public event Action TookDamage = delegate { };


    public void TakeDamage(int damage)
    {
        TookDamage?.Invoke();
        health -= damage;
        Debug.Log("health: " + health);
        if(health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
