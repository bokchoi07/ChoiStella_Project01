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
    public event Action Died = delegate { };

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Kill();
            Time.timeScale = 0;
        }
        else 
            TookDamage?.Invoke();
    }

    public void Kill()
    {
        Died?.Invoke();
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
