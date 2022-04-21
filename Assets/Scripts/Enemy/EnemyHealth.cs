using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth = 100;

    public bool IsDead { get; private set; }

    Animator _animator;
    BoxCollider _boxCollider;
    ScreenBloodEffect _screenBloodEffect;
    EnemySFX _enemySFX;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _boxCollider = GetComponent<BoxCollider>();
        _screenBloodEffect = FindObjectOfType<ScreenBloodEffect>();
        _enemySFX = GetComponent<EnemySFX>();
    }

    public void DamageTaken()
    {
        if (_screenBloodEffect != null)
        {
            _screenBloodEffect.IsDamageTaken = true;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (enemyHealth <= 0)
        {
            Die();
        }
        else
        {
            enemyHealth--;
        }
    }

    void Die()
    {
        IsDead = true;
        _boxCollider.enabled = false;
        _animator.SetTrigger("Death");
        HandleZombieSFX();
    }

    void HandleZombieSFX()
    {
        _enemySFX.StopZombieSFX();
        _enemySFX.PlayZombieDieSFX();
    }
}
