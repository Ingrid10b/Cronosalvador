using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ataque : MonoBehaviour
{
    public int damage = 10;
    public float attackCooldown = 2.0f;
    private float lastAttackTime = 0.0f;
    private Animator animator;


    private Transform enemy; // Referencia al objeto del jugador.
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GameObject.FindWithTag("Enemy").transform; // Asigna el jugador por etiqueta "Player".
        navMeshAgent = GetComponent<NavMeshAgent>();



    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            // Realiza la lógica de ataque al jugador aquí.
            vidaEnemigo playerHealth = enemy.GetComponent<vidaEnemigo>();
            if (playerHealth != null)
            {

                playerHealth.TakeDamage(damage);
                lastAttackTime = Time.time;
            }
        }
    }
}
