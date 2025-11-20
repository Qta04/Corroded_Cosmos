using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasRecarga : MonoBehaviour
{
    public int recarga = 10; // Cantidad de balas que se recargarán
    private GunController playerScript; // Referencia al script del controlador de armas del jugador
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) // Verifica si el objeto que colisiona tiene la etiqueta "Player"
        {
            playerScript = collision.GetComponent<GunController>(); // Obtiene el componente GunController del objeto que colisionó
            AudioManager.instance.PlayItem(); // Reproduce el sonido de recoger un ítem

            if (playerScript != null) // Verifica si se obtuvo correctamente el script del jugador
            {
                playerScript.Reload(recarga); // Llama al método Reload en el script del jugador para recargar balas
                Destroy(gameObject); // Destruye el objeto después de ser recogido
            }
        }
    }
}
