using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    void Start()	{
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(new Vector3(target.position.x, target.position.y, transform.position.z));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("TouchedArea");
    }
}
