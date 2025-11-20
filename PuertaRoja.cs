using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaRoja : MonoBehaviour
{
    private Animator animator; // Componente Animator para manejar las animaciones de la puerta
    public TarjetasManager tarjetasManager; // Referencia al gestor de tarjetas
    public GameObject aviso; // Objeto que muestra un aviso al jugador
    private bool isOpen; // Indica si la puerta está abierta

    void Start()
    {
        animator = GetComponentInChildren<Animator>(); // Obtiene el componente Animator del hijo
        isOpen = false; // Inicializa el estado de la puerta como cerrada
    }

    private void Update()
    {
        animator.SetBool("isOpen", isOpen); // Actualiza el parámetro "isOpen" en el Animator
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona es el jugador y si tiene la tarjeta roja
        if (other.CompareTag("Player") && tarjetasManager.TarjetaRoja)
        {
            isOpen = true; // Marca la puerta como abierta
        }
        else
        {
            aviso.SetActive(true); // Muestra el aviso si el jugador no tiene la tarjeta
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isOpen = false; // Marca la puerta como cerrada
        aviso.SetActive(false); // Oculta el aviso
    }
}
