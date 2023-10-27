using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAI : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion anguloGiro;
    public float grado;


    void Start()
    {
        ani = GetComponent<Animator>();
        //navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void ComportamientoEnemigo()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;
        }
        switch (rutina)
        {
            case 0:
                //el enemigo se mantendrá quieto
                ani.SetBool("Walk", false);
                break;
            case 1:
                //determinamos la dirección en la que desplaza el enemigo
                grado = Random.Range(0, 360);
                anguloGiro = Quaternion.Euler(0, grado, 0);
                rutina++;
                break;
            case 2:
                //determinamos el movimiento del enemigo
                //la rotacion del enemigo es = al angulo establecido anteriormente
                transform.rotation = Quaternion.RotateTowards(transform.rotation, anguloGiro, 0.5f);
                //se mueve hacia adelante con una velocidad de 1
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                //activamos la animacion de caminar
                ani.SetBool("Walk", true);
                break;
        }
    }

    void Update()
    {
        ComportamientoEnemigo();
        //navMeshAgent.SetDestination(target.position);
    }
}
