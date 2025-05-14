using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private bool isRanged;

    private const string IsAttack = nameof(IsAttack);

    private NavMeshAgent agent;
    private Transform playerT;
    private Animator animator;

    private RaycastHit hit;

    private bool hasTarget;

    private PlayerSettings playerSettings;
    private EffectDamagePlayer effectDamagePlayer;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerT = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();

        if (isRanged)
            InvokeRepeating(nameof(CheckIsSpottedPlayer), 0f, 1f);
        else
        {
            GameObject player = FindObjectOfType<PlayerController>().gameObject;
            playerSettings = player.GetComponent<PlayerSettings>();
            effectDamagePlayer = player.GetComponent<EffectDamagePlayer>();
        }
    }


    void Update()
    {
        if (isRanged)
            RangedEnemyBehavior();
        else
            MeleeEnemyBehavior();
    }

    public void AttackMelee()
    {
        playerSettings.Damage(20);
        effectDamagePlayer.ShowEffectDamage();
    }

    private void RangedEnemyBehavior()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerT.position);
        if (distanceToPlayer < 20f && hasTarget)
        {
            Attack();
        }
        else
        {
            MoveToPlayer();
        }
    }

    private void MeleeEnemyBehavior()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerT.position);
        if (distanceToPlayer < 3f)
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


}
