using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemigo : MonoBehaviour
{
    public int damage = 10;
    public float attackCooldown = 2.0f;
    private float lastAttackTime = 0.0f;
    private Animator animator;


    private Transform player; // Referencia al objeto del jugador.
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform; // Asigna el jugador por etiqueta "Player".
        navMeshAgent = GetComponent<NavMeshAgent>();



    }
    private void Update()
    {
        if (player != null)
        {
            // Sigue al jugador.
            navMeshAgent.SetDestination(player.position);

            if (Vector3.Distance(transform.position, player.position) <= navMeshAgent.stoppingDistance)
            {
                // El enemigo ha alcanzado al jugador, atacar.
                Attack();
            }
        }
    }

    private void Attack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            // Realiza la lógica de ataque al jugador aquí.
            Vida playerHealth = player.GetComponent<Vida>();
            if (playerHealth != null)
            {

                playerHealth.TakeDamage(damage);
                animator.SetTrigger("atacar");
                lastAttackTime = Time.time;
            }
        }
    }
}
