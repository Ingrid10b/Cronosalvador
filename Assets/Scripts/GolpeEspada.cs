﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpeEspada : MonoBehaviour
{
    [SerializeField]
    public float attackCooldown = 2.0f; // Rango de ataque
    public int damage = 10; // Daño causado por el jugador
   // public string enemyTag = "Boss"; // Etiqueta del enemigo

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackCooldown);
        foreach (Collider enemyCollider in hitEnemies)
        {
            if (enemyCollider.gameObject.CompareTag("Boss"))
            {
                vidaBoss enemyHealth = enemyCollider.GetComponent<vidaBoss>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
        }
    }
}