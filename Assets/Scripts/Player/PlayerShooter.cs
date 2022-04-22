using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] float recoilForceMagnitude = 50f;

    Rigidbody _rigidbody;
    PlayerSFX _playerSFX;
    PlayerVFX _playerVFX;

    bool _isFiring;
    bool _isRecoilTriggered;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerSFX = GetComponent<PlayerSFX>();
        _playerVFX = GetComponent<PlayerVFX>();
    }

    void Update()
    {
        HandleShoot();
    }

    void FixedUpdate()
    {
        ApplyRecoilForce();
    }

    void OnFire(InputValue button)
    {
        _isFiring = button.isPressed;
    }

    void HandleShoot()
    {
        if (_isFiring && !_playerVFX.ShootVFXIsPlaying())
        {
            _playerVFX.PlayShootVFX();
            _playerVFX.PlayShootLightEffect();
            _playerSFX.PlayShotgunSFX();
            _isRecoilTriggered = true;
        }
        else
        {
            _isFiring = false;
        }
    }

    void ApplyRecoilForce()
    {
        if (_isRecoilTriggered)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddRelativeForce((Vector3.back * recoilForceMagnitude));
            _isRecoilTriggered = false;
        }
    }
}
