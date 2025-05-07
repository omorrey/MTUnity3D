using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerT;
    public int health = 10;

    
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       playerT = GameObject.Find("Player").transform;
    }


    void Update()
    {
        MoveToPlayer();

        
        // if (health > 1)
        // {
        //     float distanceToPlayer = Vector3.Distance(transform.position, playerT.position);
        //     if (distanceToPlayer < 2.5f)
        //     {
        //         Attack();
        //     }
        //     else
        //     {
                
        //         MoveToPlayer();
        //     }
        // }
    }

    private void MoveToPlayer()
    {
        agent.destination = playerT.position;
    }
    private void Attack()
    {

    }

}
