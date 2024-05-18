using System.Collections;
using System.Collections.Generic;
using NavMeshComponents.Extensions;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy_ZombieAI : MonoBehaviour
{

    public Transform _player;
    NavMeshAgent _agent;

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
        _agent.SetDestination(_player.position);
    }
}
