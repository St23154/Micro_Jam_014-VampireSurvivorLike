using System;
using System.Collections;
using System.Collections.Generic;
using NavMeshComponents.Extensions;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Ennemy_ZombieAI : MonoBehaviour
{

    public Transform _player;
    public Vector3 _tourne;
    public Vector3 _tourne1;
    NavMeshAgent _agent;
    private Animator _animator;
    public float _health = 100;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.eulerAngles != _tourne && transform.eulerAngles != _tourne1)
        {
            if(transform.eulerAngles.y - _tourne.y < transform.eulerAngles.y - _tourne1.y)
            {
                transform.eulerAngles = _tourne;
            }
            else
            {
                transform.eulerAngles = _tourne1;
            }
        }
        if(transform.position.x  - _player.position.x < 0)
        {
            if(transform.eulerAngles == _tourne)
            {
            transform.Rotate(_tourne);
            }
        }
        else
        {
            if(transform.eulerAngles != _tourne)
            {
            transform.Rotate(_tourne);
            }
        }
        _agent.SetDestination(_player.position);
    }

    public void TakeDamage(float _amount)
    {
        _health -= _amount;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
