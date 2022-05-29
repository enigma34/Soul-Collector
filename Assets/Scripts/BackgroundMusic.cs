using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    static BackgroundMusic backgroundMusic; 
    [SerializeField]
    private AudioClip bulletFireSound;
    private AudioSource _audioSource;

    void Awake()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void AdjustVolume(int volume)
    {
        AudioListener.volume = volume;
    }

    public void BulletFireSFX()
    {
        _audioSource.clip = bulletFireSound;

        _audioSource.Play();
    }
}
