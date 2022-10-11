using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLoseFX : MonoBehaviour
{
    [SerializeField] AudioClip gameOverSFX;
    [SerializeField] AudioClip winSFX;

    [SerializeField] GameObject player;
    [SerializeField] GameObject boss;

    [SerializeField] TMP_Text winLoseText;

    private void Start()
    {
        winLoseText.text = "";
        winLoseText.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        player.GetComponent<Health>().Died += OnPlayerDie;
        boss.GetComponent<Health>().Died += OnBossDie;
    }

    private void OnDisable()
    {
        player.GetComponent<Health>().Died -= OnPlayerDie;
        boss.GetComponent<Health>().Died -= OnBossDie;
    }

    public void OnPlayerDie()
    {
        AudioHelper.PlayClip2D(gameOverSFX, 1f);
        winLoseText.text = "you lose!";
        winLoseText.gameObject.SetActive(true);

        boss.GetComponent<Boss>().playerAlive = false;
    }

    public void OnBossDie()
    {
        AudioHelper.PlayClip2D(winSFX, 1f);
        winLoseText.text = "you win!";
        winLoseText.gameObject.SetActive(true);
    }
}
