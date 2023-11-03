using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemigo : MonoBehaviour
{
    //atacar
    public int damage = 10;
    public float attackCooldown = 2.0f;
    private float lastAttackTime = 0.0f;

    //control animations
    private Animator animator;

    //stop personaje 
    private NavMeshAgent nM;
    public float originalSpeed;
    public float slowTimer;
    public float stopFactor = 0f;

    //var rotation
    public float x;
    public float velocityRotation;

    private Transform player; // Referencia al objeto del jugador.
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        nM = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform; // Asigna el jugador por etiqueta "Player".
        navMeshAgent = GetComponent<NavMeshAgent>();
        originalSpeed = GetComponent<NavMeshAgent>().speed;
        slowTimer = 0.0f;

    }
    private void Update()
    {

        //asignamos valores a los ejes x
        x = Input.GetAxis("Horizontal");

        transform.Rotate(0, x * Time.deltaTime * velocityRotation, 0);
        animator.SetFloat("VelX", x);

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

    public void ApplySlowEffect(float factor)
    {
        float duration = 5.0f;
        GetComponent<NavMeshAgent>().speed = originalSpeed * factor;
        slowTimer = duration;
        StartCoroutine(RestoreSpeedAfterDelay(duration));
    }

    private void Attack()
    {

        if (Time.time - lastAttackTime >= attackCooldown)
        {
    
            Vida playerHealth = player.GetComponent<Vida>();
            if (playerHealth != null)
            {

                playerHealth.TakeDamage(damage);
                animator.SetTrigger("atacar");
                lastAttackTime = Time.time;
                ApplySlowEffect(stopFactor);
            }
        }
    }

    private IEnumerator RestoreSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<NavMeshAgent>().speed = originalSpeed;
    }
}
