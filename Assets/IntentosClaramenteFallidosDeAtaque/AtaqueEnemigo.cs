using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AtaqueEnemigo : MonoBehaviour
{
    public float attackCooldown = 2.0f; // Rango de ataque
    public int damage = 10; // Daño causado por el jugador
    public GameObject bossEnemy;
    public GameObject enemyOfTheNight;
    private NavMeshAgent navMeshAgent;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
           
                AttackEnemies(bossEnemy);
                //AttackEnemies(enemyOfTheNight);
         
        }
    }

    public void AttackEnemies(GameObject enemy)
    {
        Debug.Log("1");
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackCooldown);

        foreach (Collider enemyCollider in hitEnemies)
        {
            //Debug.Log(hitEnemies);

            if (enemyCollider.gameObject == enemy)
            {
                Debug.Log("3");

                vidaBoss enemyHealth = enemyCollider.GetComponent<vidaBoss>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
        }
    }

    private void Start()
    {
       navMeshAgent = GetComponent<NavMeshAgent>();
    }
}
