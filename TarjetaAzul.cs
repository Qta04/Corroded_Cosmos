using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarjetaAzul : MonoBehaviour
{
    public GameObject keyImage; // Imagen que representa la tarjeta azul en la interfaz
    public GameObject keyaviso; // Aviso que se muestra al recoger la tarjeta
    public TarjetasManager tarjetasManager; // Referencia al gestor de tarjetas
    
    void Start()
    {
        keyImage.SetActive(false); // Inicializa la imagen de la tarjeta como inactiva
        keyaviso.SetActive(false); // Inicializa el aviso como inactivo
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlayItem(); // Reproduce el sonido de recolección
            tarjetasManager.TarjetaAzul = true; // Marca la tarjeta azul como recogida
            keyImage.SetActive(true); // Muestra la imagen de la tarjeta
            keyaviso.SetActive(true); // Muestra el aviso de recolección
            StartCoroutine(Aviso()); // Inicia la coroutine para ocultar el aviso después de un tiempo
        }
    }
    private IEnumerator Aviso() // Coroutine que maneja la duración del aviso
    {
        yield return new WaitForSeconds(3f); // Espera 3 segundos
        keyaviso.SetActive(false); // Oculta el aviso
        Destroy(gameObject); // Destruye el objeto de la tarjeta azul
    }
}
