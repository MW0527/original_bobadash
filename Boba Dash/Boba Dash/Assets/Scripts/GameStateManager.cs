using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip lose_sound;

    private static GameStateManager _instance;
    void Start()
    {
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(_instance);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public static void GameOver() //declared public as other classes call this method
    {
        SoundManager.PlaySFX(_instance.lose_sound);
        SceneManager.LoadScene(2); //loads Game Over scene
    }
}
