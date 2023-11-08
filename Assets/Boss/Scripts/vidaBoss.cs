using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class vidaBoss : MonoBehaviour
{
    public int maxHealth = 50;
    public bool isDead = false;
    public int currentHealth;
    private Animator animator;
    public GameObject Enemigo;
    public bool Crab;


    private void Start()
    {
        animator = GetComponent<Animator>();


    }

    public void TakeDamage(int damage)
    {
        if (isDead == true) return;
        currentHealth -= damage;    
        if (currentHealth <= 0 ){Death();}
    }

    void Death()
    {
        isDead = true;
        if (Crab)
        {
            animator.SetTrigger("Die");
            Destroy(gameObject, 2);

        }else 
        {
            animator.SetTrigger("death");
            Destroy(gameObject, 2);

        }

    }

    //private void OnCollisionEnter(Collision collision)
   // {
       // if (collision.gameObject.CompareTag("Bullet")) {
           // TakeDamage(10);
        //}
   // }
}


