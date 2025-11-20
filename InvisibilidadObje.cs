using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilidadObje : MonoBehaviour
{
    public float invisibilityDuration = 5f; // Duración de la invisibilidad

    // Método llamado cuando otro collider entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // Obtiene todos los objetos con la etiqueta "Player"
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            AudioManager.instance.PlayItem(); // Reproduce el sonido de recoger el ítem

            // Recorre todos los jugadores y activa la invisibilidad
            foreach (GameObject playerObject in players)
            {
                // Obtiene el componente Invisibilidad del objeto jugador
                Invisibilidad player = playerObject.GetComponent<Invisibilidad>();
                if (player != null)
                {
                    // Activa la invisibilidad en el jugador
                    player.ActivateInvisibility(invisibilityDuration);
                }
            }
            // Destruye el objeto de invisibilidad después de ser recogido
            Destroy(gameObject);
        }
    }
}

