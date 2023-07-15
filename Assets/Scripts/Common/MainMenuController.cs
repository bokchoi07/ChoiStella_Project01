using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    //[SerializeField] AudioClip _startingSong;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //if (_startingSong != null)
        {
            //AudioManager.Instance.PlaySong(_startingSong);
        }
    }
}
