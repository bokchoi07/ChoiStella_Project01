using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Health healthScript = null;

    public Slider slider;

    private void Start()
    {
        slider.value = healthScript.GetMaxHealth();
    }

    private void OnEnable()
    {
        healthScript.TookDamage += OnTakeDamage;
    }

    private void OnDisable()
    {
        healthScript.TookDamage -= OnTakeDamage;
    }

    public void OnTakeDamage()
    {
        if(healthScript.GetHealth() <= 0)
        {
            slider.value = 0;
        }
        else
        {
            slider.value = healthScript.GetHealth();
        }
    }
}
