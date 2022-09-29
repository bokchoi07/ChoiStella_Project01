using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Health playerHealthScript;
    [SerializeField] private GameObject damageScreenImage;

    private void Start()
    {
        damageScreenImage.SetActive(false);
    }
    private void OnEnable()
    {
        playerHealthScript.TookDamage += OnTakeDamage;
    }

    private void OnDisable()
    {
        playerHealthScript.TookDamage -= OnTakeDamage;
    }

    private void OnTakeDamage()
    {
        StartCoroutine(Shake(.15f, .4f));
        //StartCoroutine(DamageScreen(.15f));

        damageScreenImage.SetActive(false);
    }

    public IEnumerator DamageScreen (float duration)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {

        }

        damageScreenImage.SetActive(true);

        yield return null;
    }

    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            damageScreenImage.SetActive(true);
            float x = Random.Range(-1f, 1f) * magnitude;
            float z = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, originalPos.y, z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
        damageScreenImage.SetActive(false);
    }
}
