using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float detectionRange = 5f;
    [SerializeField] float turnSpeed = 2f;

    NavMeshAgent _navMeshAgent;
    Animator _animator;
    EnemyHealth _enemyHealth;
    EnemySFX _enemySFX;

    float _currentDistance;
    bool _isProvoked;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _enemySFX = GetComponent<EnemySFX>();
    }

    void Update()
    {
        if (_enemyHealth.IsDead)
        {
            _navMeshAgent.enabled = false;
            return;
        }

        _currentDistance = Vector3.Distance(target.position, transform.position);

        if (_isProvoked)
        {
            EngageTarget();
        }
        else if (_currentDistance <= detectionRange)
        {
            _isProvoked = true;
        }
    }


    void OnParticleCollision(GameObject other)
    {
        _isProvoked = true;
    }

    void EngageTarget()
    {
        FaceTarget();
        PlayZombieEngageSFX();

        if (_currentDistance > _navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (_currentDistance < _navMeshAgent.stoppingDistance)
        {
            AttackTarget(true);
        }
    }

    void PlayZombieEngageSFX()
    {
        if (!_enemySFX.ZombieSFxIsPlaying())
        {
            _enemySFX.PlayZombieSFX();
        }
    }

    void AttackTarget(bool state)
    {
        _animator.SetBool("Attack", state);
    }

    void ChaseTarget()
    {
        AttackTarget(false);
        _navMeshAgent.SetDestination(target.position);
        _animator.SetTrigger("Walk");
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
