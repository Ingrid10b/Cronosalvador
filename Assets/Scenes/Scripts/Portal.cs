using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform ArenaDeBatalla;
    public GameObject Player;

    
    private void OnTriggerEnter(Collider other)
    {
        Player.transform.position = ArenaDeBatalla.transform.position;
    
    }
   
}


