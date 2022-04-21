using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFX : MonoBehaviour
{
    [SerializeField] AudioClip zombieDieSFX;

    AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayZombieSFX()
    {
        _audioSource.Play();
    }

    public void StopZombieSFX()
    {
        _audioSource.Stop();
    }

    public bool ZombieSFxIsPlaying()
    {
        return _audioSource.isPlaying;
    }

    public void PlayZombieDieSFX()
    {
        _audioSource.PlayOneShot(zombieDieSFX);
        Debug.Log("Die sound played");
    }
}
