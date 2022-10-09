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
        TookDamage?.Invoke();
        Debug.Log("health: " + health);

        /*if(gameObject.tag == "Player")
        {
            StartCoroutine(cameraShake.Shake(.15f, .4f));
        }*/
        
        if (health <= 0)
        {
            Kill();
        }
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
