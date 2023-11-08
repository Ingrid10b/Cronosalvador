using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Utility;

public class menuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject MenuGameOver;

    private Vida vidaJugador;

    public bool activeMenuGO;

    private void Start()
    {
        vidaJugador = GameObject.FindWithTag("Player").GetComponent<Vida>();
        vidaJugador.gameOver += ActivarMenu;
    }

    private void ActivarMenu(object sender, EventArgs e)
    {
        MenuGameOver.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
    }
}