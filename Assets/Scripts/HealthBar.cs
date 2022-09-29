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
        slider.maxValue = healthScript.GetMaxHealth();
    }

    private void OnEnable()
    {
        healthScript.TookDamage += OnTakeDamage;
        healthScript.Died += OnDie;
    }

    private void OnDisable()
    {
        healthScript.TookDamage -= OnTakeDamage;
        healthScript.Died -= OnDie;
    }

    public void OnTakeDamage()
    {
        slider.value = healthScript.GetHealth();
    }

    public void OnDie()
    {
        slider.value = 0;
    }
}
