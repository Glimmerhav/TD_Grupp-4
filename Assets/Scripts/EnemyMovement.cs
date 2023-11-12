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
        SetTarget();
    }

    private void FixedUpdate()
    {
        Destroy();
    }
    void SetTarget()
    {
        if (player == null) { return; }

        agent.SetDestination(player.transform.position);
    }
    private void Destroy()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) >= 60f)
        {
            Destroy(gameObject);
        }
    }


}
