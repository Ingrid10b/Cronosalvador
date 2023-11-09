using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{   //variable
    public float minutos, grados;
    public float TimeSpeed = 50;
    public Light Luna;


    void Update()
    {
        // 1dia 24mins
        minutos += TimeSpeed * Time.deltaTime; //1min = 1sgs
        if (minutos >= 1440) //1440sgs = 24hs
        {
            minutos = 0;
        }
        //360 / 1440 => 1º = 0.25min 
        grados = minutos / 4;
        this.transform.localEulerAngles = new Vector3(grados, 90f, 0);
        if (grados >= 180)
        { 
            this.GetComponent<Light>().enabled = false;
            Luna.enabled = true;
        }
        else
        {
            this.GetComponent<Light>().enabled = true;
            Luna.enabled = false;
        }
      
    }
}
