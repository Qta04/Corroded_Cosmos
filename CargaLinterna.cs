using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargaLinterna : MonoBehaviour
{
    public Image rellenoCarga; // Referencia a la imagen del relleno de la bateria
    private FunciLinterna linterna; // Instancia de la clase FunciLinterna

    void Start()
    {
        // Al iniciar, se busca la instancia de FunciLinterna en la escena
        linterna = FindObjectOfType<FunciLinterna>();
    }


void Update()
{
    // Actualiza el fillAmount de la imagen rellenoCarga basado en la carga actual de la linterna
    rellenoCarga.fillAmount = linterna.CargaBateria / linterna.CargaMax;
    // Llama a la función para actualizar el color del slider según el nivel de carga
    ActualizarColorSlider();
}

void ActualizarColorSlider()
{
    // Cambia el color del slider según el nivel de carga de la batería
    if (linterna.CargaBateria > 50)
    {
        // Si la carga es mayor a 50, establece el color a verde
        rellenoCarga.color = Color.green; // Verde
    }
    else if (linterna.CargaBateria > 20)
    {
        // Si la carga es mayor a 20 pero menor o igual a 50, establece el color a amarillo
        rellenoCarga.color = Color.yellow; // Amarillo
    }
    else
    {
        // Si la carga es 20 o menor, establece el color a rojo
        rellenoCarga.color = Color.red; // Rojo
    }
}
}
