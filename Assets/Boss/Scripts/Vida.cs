using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
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
            // El jugador murió, aquí puedes realizar las acciones necesarias.
            // Por ejemplo, reiniciar el juego o mostrar un mensaje de derrota.
            Debug.Log("El jugador murió");
        }

    }
}
