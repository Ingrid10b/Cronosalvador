using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Velocidad : MonoBehaviour
{
    public float velocidadInicial = 5f;
    public float velocidadReducida = 2f;
    public float tiempoParaReducirVelocidad = 5f;
    public Slider SliderVelocidad;


    private float tiempoTranscurrido = 0f;
    private bool colisionConAlimento = false;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * velocidadInicial; // Inicializa la velocidad del jugador
    }

    private void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= tiempoParaReducirVelocidad && !colisionConAlimento)
        {
            // Reducir la velocidad del jugador
            rb.velocity = transform.forward * velocidadReducida;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("apple"))
        {
            // Si el jugador colisiona con un objeto etiquetado como "Apple", restaurar la velocidad inicial
            colisionConAlimento = true;
            rb.velocity = transform.forward * velocidadInicial;
        }
    }
}
