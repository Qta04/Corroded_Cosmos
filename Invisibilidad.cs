using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibilidad : MonoBehaviour
{
    public Material invisible; // Material que se usará cuando el objeto esté invisible
    public Material visible; // Material que se usará cuando el objeto esté visible
    public static Invisibilidad instance; // Instancia estática para acceso global
    private bool isInvisible = false; // Indica si el objeto está actualmente invisible

    // Método para activar la invisibilidad
    public void ActivateInvisibility(float duration)
    {
        // Verifica si el objeto no está ya invisible
        if (!isInvisible)
        {
            isInvisible = true; // Marca el objeto como invisible
            StartCoroutine(InvisibilityCoroutine(duration)); // Inicia la coroutine para manejar la duración de la invisibilidad
        }
    }

    // Coroutine que maneja la invisibilidad durante un tiempo determinado
    private IEnumerator InvisibilityCoroutine(float duration)
    {
        // Cambia el material del objeto a invisible
        GetComponent<MeshRenderer>().material = invisible;
        yield return new WaitForSeconds(duration); // Espera la duración especificada
        isInvisible = false; // Marca el objeto como visible nuevamente
        // Cambia el material del objeto a visible
        GetComponent<MeshRenderer>().material = visible;
    }

    // Método que verifica si el objeto está invisible
    public bool IsInvisible()
    {
        return isInvisible; // Devuelve el estado de invisibilidad
    }
}
