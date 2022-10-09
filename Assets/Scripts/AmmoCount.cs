using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCount : MonoBehaviour
{
    [SerializeField] TMP_Text ammoText;
    [SerializeField] Player playerScript;

    private void Start()
    {
        ammoText.text = playerScript.maxAmmo.ToString();
    }

    private void OnEnable()
    {
        playerScript.AmmoChange += OnAmmoChange;
    }

    private void OnDisable()
    {
        playerScript.AmmoChange -= OnAmmoChange;
    }

    public void OnAmmoChange(int ammoCount)
    {
        ammoText.text = ammoCount.ToString();

        if(ammoCount == 0)
        {
            ammoText.color = Color.red;
        }

        if(ammoCount > 0)
        {
            ammoText.color = Color.white;
        }
    }
}
