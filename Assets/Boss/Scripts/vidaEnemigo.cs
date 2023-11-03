using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemigo : MonoBehaviour
{
    public int maxHealth = 50;
    public bool isDead;
    public int currentHealth;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead == true) return;
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if ()
            {
            Death();
                
            }
            DeathMonsterNight();
            Debug.Log("El enemigo murió");
        }

    }

    void Death()
    {
        isDead = true;
        animator.SetTrigger("death");
        Destroy(gameObject, 2);
    }

    void DeathMonsterNight()
    {
        isDead = true;
        animator.SetTrigger("die");
        Destroy(gameObject, 2);
    }
}
