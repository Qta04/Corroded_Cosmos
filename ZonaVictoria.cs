using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZonaVictoria : MonoBehaviour
{
    [SerializeField] GameObject PanelVictoria;
    [SerializeField] Timer timer; // Referencia al script Timer
    TextMeshProUGUI textoPuntaje; // Referencia al TextMeshProUGUI

    private void Start()
    {
        // Obtiene el componente TextMeshProUGUI del PanelPuntaje
        textoPuntaje = PanelVictoria.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider colision)
    {
        if (colision.CompareTag("Player"))
        {
            // Activa el panel de puntaje
            PanelVictoria.SetActive(true);
            
            // Detiene el temporizador
            timer.StopTimer(); 

            // Muestra el tiempo transcurrido en el texto del panel
            textoPuntaje.text = timer.GetElapsedTime();
        }
        else
        {
            PanelVictoria.SetActive(false);
        }
    }
}
