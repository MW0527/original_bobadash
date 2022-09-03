using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource SFX_source;

    private static SoundManager _instance;
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);

        }
    }

    public static void PlaySFX(AudioClip clip)
    {
        _instance.SFX_source.PlayOneShot(clip);
    }
}
