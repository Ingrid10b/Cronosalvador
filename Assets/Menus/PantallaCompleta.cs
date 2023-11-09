 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class PantallaCompleta : MonoBehaviour
{
    public Toggle toggle;

    public TMP_Dropdown resolucion;
    Resolution[] resoluciones;

    // Start is called before the first frame update
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        } else
        {
            toggle.isOn = false;
        }

        RevisarResolucion();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void RevisarResolucion()
    {
        resoluciones = Screen.resolutions;
        resolucion.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;


        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }

        }
            resolucion.AddOptions(opciones);
            resolucion.value = resolucionActual;
            resolucion.RefreshShownValue();

        resolucion.value = PlayerPrefs.GetInt("numeroResolucion", 0);

    }


    public void CambiarResolucion(int indiceResolucion)
    {
        PlayerPrefs.SetInt("numeroResolucion", resolucion.value);

        Resolution changeResolution = resoluciones[indiceResolucion];
        Screen.SetResolution(changeResolution.width, changeResolution.height, Screen.fullScreen);
    } 
}
