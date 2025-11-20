using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FunciLinterna : MonoBehaviour
{
    public static FunciLinterna Instance; // Instancia estática para acceso global
    public Light linteral; // Componente de luz de la linterna
    public TextMeshProUGUI uiCarga; // Texto que muestra el nivel de carga de la batería
    public float CargaBateria; // Carga actual de la batería
    public float CargaMax; // Carga máxima de la batería
    public float consumoPorSegundo; // Consumo de batería por segundo
    void Start()
    {
        linteral.enabled = false; // Asegura que la linterna esté apagada al inicio
    }

    void Update()
    {
        Prender(); // Verifica si se debe encender la linterna
        ActualizarCargaBateria(); // Actualiza el estado de la batería
    }
    void Prender() // Método que verifica si se debe encender la linterna
    {
        // Si se presiona la tecla X, se alterna el estado de la linterna
        if (Input.GetKeyDown(KeyCode.X))
        {
            linternaON();
        }
    }

    public void linternaON() // Método para encender o apagar la linterna
    {
        linteral.enabled = !linteral.enabled; // Cambia el estado de la linterna
    }

    // Método que actualiza la carga de la batería
    void ActualizarCargaBateria()
    {
        if (linteral.enabled) // Si la linterna está encendida
        {
            // Reduce la carga de la batería según el consumo por segundo
            CargaBateria -= consumoPorSegundo * Time.deltaTime; 
            CargaBateria = Mathf.Max(CargaBateria, 0); // Asegura que la carga no sea negativa

            // Si la batería se agota, apaga la linterna
            if (CargaBateria <= 0)
            {
                linteral.enabled = false; // Apaga la linterna
            }
        }
        BatteryText(); // Actualiza el texto que muestra la carga de la batería
    }

    // Método que actualiza el texto de la carga de la batería en la interfaz
    public void BatteryText()
    {
        uiCarga.text = (int)CargaBateria + " %"; // Muestra el porcentaje de carga
    }

    // Método para recargar la batería
    public void Recarga(int pila)
    {
        // Asegura que la carga no exceda la carga máxima
        if ((CargaBateria + pila) > CargaMax)
        {
            CargaBateria = CargaMax; // Establece la carga a la máxima si se excede
        }
        else
        {
            CargaBateria += pila; // Aumenta la carga de la batería
        }
        BatteryText(); // Actualiza el texto de la carga
    }
}
