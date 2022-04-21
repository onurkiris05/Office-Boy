using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairSFX : MonoBehaviour
{
    AudioSource _audioSource;
    PlayerController _playerController;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _playerController = GetComponentInParent<PlayerController>();
    }

    void Update()
    {
        PlayChairSFX();
    }

    void PlayChairSFX()
    {
        if (_playerController.MoveInput != Vector2.zero && !_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
        else if (_playerController.MoveInput == Vector2.zero && _audioSource.isPlaying)
        {
            _audioSource.Pause();
        }
    }
}
