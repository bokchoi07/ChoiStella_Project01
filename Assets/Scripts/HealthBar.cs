using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Health healthScript = null;

    public Gradient gradient;
    public Slider slider;
    public Image fill;

    private void Start()
    {
        slider.maxValue = healthScript.GetMaxHealth();
        fill.color = gradient.Evaluate(1f);
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

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void OnDie()
    {
        slider.value = 0;
    }
}
