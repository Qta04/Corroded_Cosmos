using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoCarga : MonoBehaviour
{
   public int escudo = 30; // Cantidad de escudo que se otorgará al jugador
    public GameObject escudoAviso; // Objeto que muestra un aviso visual al recoger el escudo
    private VidaJugador playerScript; // Referencia al script de vida del jugador
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) // Verifica si el objeto que colisiona tiene la etiqueta "Player"
        {
            // Obtiene el componente VidaJugador del objeto que colisionó
            playerScript = collision.GetComponent<VidaJugador>();

            // Verifica si se obtuvo correctamente el componente
            if (playerScript != null)
            {
                // Llama al método Escudo en el script de VidaJugador para añadir escudo
                playerScript.Escudo(escudo);
                // Reproduce el sonido de recoger un ítem
                AudioManager.instance.PlayItem();
                // Activa el aviso de escudo
                escudoAviso.SetActive(true);
                // Inicia la coroutine para manejar el aviso
                StartCoroutine(Aviso());
            }
        }
    }

    // Coroutine que maneja el tiempo de duración del aviso
    private IEnumerator Aviso() 
    {
        // Desactiva el aviso de escudo
        escudoAviso.SetActive(false);
        // Espera 3 segundos
        yield return new WaitForSeconds(3f);
        // Destruye el objeto de escudo (si no se ha destruido ya)
        Destroy(gameObject);
    }
}
