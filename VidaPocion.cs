using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPocion : MonoBehaviour
{
    public int curacion = 10; // Cantidad de salud que se restaurará al jugador
    private VidaJugador playerScript; // Referencia al script de VidaJugador

    private void OnTriggerEnter(Collider collision)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayItem(); // Reproduce el sonido de recolección
            playerScript = collision.GetComponent<VidaJugador>(); // Obtiene el componente VidaJugador del jugador

            // Verifica si se obtuvo el script de VidaJugador
            if (playerScript != null)
            {
                playerScript.Curacion(curacion); // Llama al método de curación en el script del jugador
                Destroy(gameObject); // Destruye el objeto de curación
            }
        }
    }
}
