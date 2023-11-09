﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPausa : MonoBehaviour
{
    public GameObject menuDePausa;
    public bool activeMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            activeMenu = !activeMenu;
        }
        if (activeMenu == true)
        {
            menuDePausa.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        } else
        {
            Continue();
        }
    }

    public void Continue()
    {
        menuDePausa.SetActive(false);
        Time.timeScale = 1f;
        activeMenu = false;
    }
}