using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    public AudioSource BgmAudSource;
    public AudioSource SfxAudSource;
    public AudioClip[] SfxClips;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySfx(int clipIndex)
    {
        if (SfxAudSource != null)
        {
            SfxAudSource.PlayOneShot(SfxClips[clipIndex], 1f);
        } 
    }
}
