using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLoseAudio : MonoBehaviour
{
    [SerializeField] AudioClip gameOverSFX;
    [SerializeField] AudioClip winSFX;

    [SerializeField] Health playerHealthScript;
    [SerializeField] Health bossHealthScript;

    [SerializeField] TMP_Text winLoseText;

    private void Start()
    {
        winLoseText.text = "";
        winLoseText.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        playerHealthScript.Died += OnPlayerDie;
        bossHealthScript.Died += OnBossDie;
    }

    private void OnDisable()
    {
        playerHealthScript.Died -= OnPlayerDie;
        bossHealthScript.Died -= OnBossDie;
    }

    public void OnPlayerDie()
    {
        AudioHelper.PlayClip2D(gameOverSFX, 1f);
        winLoseText.text = "you lose!";
        winLoseText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnBossDie()
    {
        AudioHelper.PlayClip2D(winSFX, 1f);
        winLoseText.text = "you win!";
        winLoseText.gameObject.SetActive(true);
    }
}
