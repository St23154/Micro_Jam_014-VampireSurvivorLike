using System.Collections;
using System.Collections.Generic;
using NavMeshComponents.Extensions;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemy_BatAI : MonoBehaviour
{

    public Transform _player;
    public Vector3 _tourne;
    NavMeshAgent _agent;
    private Animator _animator;

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
        _animator.SetBool("IsWalking", true);
        if(_player.position.x - transform.position.x < 0)
        {
            if(transform.rotation.y == 180)
            {
            transform.Rotate(_tourne);
            }
        }
        else
        {
            if(transform.rotation.y != 180)
            {
            transform.Rotate(_tourne);
            }
        }
        _agent.SetDestination(_player.position);
    }

}
