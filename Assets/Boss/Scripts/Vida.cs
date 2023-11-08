using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Vida : MonoBehaviour
{
    public event EventHandler gameOver;
    public GameObject vidaJugador;


    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            gameOver?.Invoke(this, EventArgs.Empty);
            vidaJugador.SetActive(false);
        }

    }
}
