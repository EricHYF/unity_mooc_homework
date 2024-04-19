using System;
using UnityEngine;
using UnityEngine.AI;

namespace Homework_8.Code
{
    public class Player:MonoBehaviour
    {
        private RaycastHit _hit;

        public NavMeshAgent _agent;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _agent.isStopped = true;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit))
                {
                    _agent.destination = _hit.point;
                    _agent.isStopped = false;
                }
            }
        }
    }
}