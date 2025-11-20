using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BateriaCarga : MonoBehaviour
{
    public GameObject bateriaAviso; // Referencia al objeto que muestra el aviso de recarga
    public int recarga = 10; // Cantidad de carga que se añadirá a la linterna
    private FunciLinterna linterna; // Referencia al script de la linterna
    void Start()
    {
        bateriaAviso.SetActive(false); // Desactiva el aviso de batería al inicio
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) // Verifica si el objeto que colisiona tiene la etiqueta "Player"
        {
            linterna = collision.GetComponent<FunciLinterna>(); // Obtiene el componente FunciLinterna del objeto que colisionó
            AudioManager.instance.PlayItem(); // Reproduce el sonido de recoger un ítem
            linterna.Recarga(recarga); // Llama al método Recarga en el script de la linterna para añadir carga
            bateriaAviso.SetActive(true); // Activa el aviso de batería
            StartCoroutine(Aviso()); // Inicia la coroutine para manejar el aviso
        }
    }

    private IEnumerator Aviso() // Coroutine que maneja el tiempo de duración del aviso
    {
        yield return new WaitForSeconds(3f); // Espera 3 segundos
        bateriaAviso.SetActive(false); // Desactiva el aviso de batería
        Destroy(gameObject); // Destruye el objeto de recarga (batería) después de ser recogido
    }
}
