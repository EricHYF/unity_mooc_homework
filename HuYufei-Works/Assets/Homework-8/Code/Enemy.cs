using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyState
{
    Idle,
    Patrolling,
    PatrollingChangeNext,
    
    Chace,
}

public class Enemy : MonoBehaviour
{
    public GameObject[] _waypoints;
    public NavMeshAgent _agent;


    private GameObject _nextWP;
    private int _wpIndex;
    private EnemyState _state;

    public float _patrollingSpeed = 6F;
    private float _stopDistance = 0.03f;
    
    
    void Start()
    {
        _state = EnemyState.Patrolling;
    }


    private GameObject GetNextWp()
    {
    
        if (_wpIndex >= _waypoints.Length)
        {
            _wpIndex = 0;
        }
        var wp=  _waypoints[_wpIndex];
        _wpIndex++;
        Debug.Log($"=== GetNextWP: {wp.name}");
        return wp;
    }



    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case EnemyState.Patrolling:
                OnPatrolling();
                break;
            case EnemyState.PatrollingChangeNext:
                OnPatrollingChangeNextPoint();
                break;
        }
    }





    private void OnPatrolling()
    {
        if (_nextWP == null) _nextWP = GetNextWp();
        _agent.speed = _patrollingSpeed;
        _agent.destination = _nextWP.transform.position;
        _agent.isStopped = false;
        if (_agent.remainingDistance < _stopDistance)
        {
            _state = EnemyState.PatrollingChangeNext;
        }
    }

    private float _waitingForNextWpTime = 0;
    private void OnPatrollingChangeNextPoint()
    {
        _agent.isStopped = true;
        if (_waitingForNextWpTime < 1)
        {
            _waitingForNextWpTime += Time.deltaTime;
        }
        else
        {
            _waitingForNextWpTime = 0;
            _state = EnemyState.Patrolling;
            _nextWP = null;
            Debug.Log($"=== OnPatrollingChangeNextPoint");
            
        }

       
    }



}
