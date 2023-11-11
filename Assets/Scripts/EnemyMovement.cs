using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;

    NavMeshAgent agent;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        //agent.autoBraking = true;
        Debug.Log(player.transform.position);
    }

    private void Update()
    {
        if (player == null) { return; }

        agent.SetDestination(player.transform.position);
    }


}
