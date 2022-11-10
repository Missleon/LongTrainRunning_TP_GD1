using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    [SerializeField]
    private Transform _destination;

    [SerializeField]
    private NavMeshAgent _navMeshAgent;

    private void Update()
    {
        _navMeshAgent.SetDestination(_destination.position);
    }
}
