using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerT;
    


    
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
  //частина нижче мабуть піде в скрипт з логікою кулі
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerSettings>().Damage();
        }
    }


}
