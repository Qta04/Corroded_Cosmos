using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta : MonoBehaviour
{
    private Animator animator; // Componente Animator para manejar las animaciones de la puerta
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
        isOpen = true; // Marca la puerta como abierta
        AudioManager.instance.PlayDoorOpen(); // Reproduce el sonido de apertura de la puerta
    }

    private void OnTriggerExit(Collider other)
    {
        isOpen = false; // Marca la puerta como cerrada
        AudioManager.instance.PlayDoorClose(); // Reproduce el sonido de cierre de la puerta
    }
}

