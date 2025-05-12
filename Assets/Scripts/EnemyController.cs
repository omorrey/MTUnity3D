using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private const string IsAttack = nameof(IsAttack);

    private NavMeshAgent agent;
    private Transform playerT;
    private Animator animator;

    private RaycastHit hit;

    private bool hasTarget;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerT = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        InvokeRepeating(nameof(CheckIsSpottedPlayer), 0f, 1f);
    }


    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerT.position);
        if (distanceToPlayer < 20f)
        {
            Attack();
        }
        else
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        agent.destination = playerT.position;
        animator.SetBool(IsAttack, false);
    }
    private void Attack()
    {
        agent.destination = transform.position;
        transform.forward = playerT.position - transform.position;
        animator.SetBool(IsAttack, true);
    }

    private void CheckIsSpottedPlayer()
    {
        Ray ray = new Ray(transform.position, playerT.position - transform.position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponent<PlayerController>())
                hasTarget = true;
            else
                hasTarget = false;
        }
        else
            hasTarget = false;
    }
    //частина нижче мабуть піде в скрипт з логікою кулі
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerSettings>().Damage();
        }
    }


}
