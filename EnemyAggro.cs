using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    public GameObject aggroMat; // luz que se activa cuando el enemigo está agresivo
    public GameObject originalMat; // Luz original del enemigo
    public bool isAggro; // Variable que define si el enemigo empieza a perseguir al jugador
    public float distanceToAggro = 8f; // Distancia a la que el enemigo comienza a perseguir al jugador
    private Transform playerTransform;  // Variable para almacenar la posición del jugador
    private void Start()
    {
        // Busca un objeto que tenga el script de PlayerMovementAndRotation y toma su transform
        playerTransform = FindAnyObjectByType<PlayerMovementAndRotation>().transform;
    }
    private void Update()
    {
        CheckEnemyAggro(); // Verifica el estado de agresión del enemigo
    }

    public void CheckEnemyAggro() // Método que verifica si el enemigo debe volverse agresivo
    {
        // Calcula la distancia entre el jugador y el enemigo
        var dist = Vector3.Distance(transform.position, playerTransform.position);

        // Si la distancia es menor a la variable, el enemigo está listo para perseguir
        if (dist < distanceToAggro)
        {
            isAggro = true; // El enemigo se vuelve agresivo
        }
        else if (dist > distanceToAggro)
        {
            isAggro = false; // El enemigo deja de ser agresivo
        }

        // Cambia la luz del enemigo según su estado de agresión
        if (isAggro && !playerTransform.GetComponent<Invisibilidad>().IsInvisible()) 
        {
            // Activa la luz de agresión si el enemigo está agresivo y el jugador no es invisible
            aggroMat.SetActive(true);
            originalMat.SetActive(false);
        }
        else
        {
            // Restaura la luz original si el enemigo no está agresivo
            aggroMat.SetActive(false);
            originalMat.SetActive(true);
        }
    }
}
