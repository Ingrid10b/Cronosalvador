using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ataque : MonoBehaviour
{
    public float attackCooldown = 2.0f; // Rango de ataque
    public int damage = 10; // Daño causado por el jugador
    public GameObject Boss;
    //private NavMeshAgent navMeshAgent;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Detecta enemigos cercanos dentro del rango de ataque
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackCooldown);

            // Aplica daño a los enemigos detectados
            foreach (Collider enemy in hitEnemies)
            {
                vidaBoss enemyHealth = enemy.GetComponent<vidaBoss>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
        }
    }




    private void Start()
    {
       // navMeshAgent = GetComponent<NavMeshAgent>();

    }


  
}
