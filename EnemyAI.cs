using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Almacena los puntos de movimiento de los enemigos
    public Transform[] points; // Array de puntos de destino

    // Define el primer destino como el primer elemento de la lista
    private int destPoint = 0; // Índice del punto de destino actual
    public float velocidadNormal; // Velocidad normal del enemigo
    public float velocidadPersiguiendo; // Velocidad del enemigo al perseguir al jugador
    private EnemyAggro enemyAggro; // Variable para almacenar el componente del script de EnemyAggro
    private Transform playerTransform; // Para almacenar el transform del jugador
    private UnityEngine.AI.NavMeshAgent navMeshAgent; // Se almacena la variable para el componente del Nav Mesh

    private void Start()
    {
        // Se llenan las variables con los componentes necesarios
        enemyAggro = GetComponent<EnemyAggro>();
        playerTransform = FindAnyObjectByType<PlayerMovementAndRotation>().transform;  
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        NextPoint(); // Llama al método para establecer el primer punto de destino
    }

    private void NextPoint() // Método para establecer el siguiente punto de destino
    {
        // Devuelve si no hay puntos de posición en el arreglo
        if (points.Length == 0)
            return;

        navMeshAgent.destination = points[destPoint].position; // Se le da destino al enemigo, el cual es el primer punto de la lista

        // Se elige el siguiente punto en la lista
        destPoint = (destPoint + 1) % points.Length; // Recorre los puntos
    }

    private void Update()
    {
        EnemyMovement(); // Llama al método para manejar el movimiento del enemigo
    }

    private void EnemyMovement() // Método que maneja el movimiento del enemigo
    {
        // Verifica si el enemigo está agresivo y el jugador no es invisible
        if (enemyAggro.isAggro && !playerTransform.GetComponent<Invisibilidad>().IsInvisible())
        {
            // Establece la posición del jugador como destino
            navMeshAgent.SetDestination(playerTransform.position);
            navMeshAgent.speed = velocidadPersiguiendo; // Cambia la velocidad a la de persecución
            navMeshAgent.stoppingDistance = 3; // Establece la distancia de parada
        }
        else if (!enemyAggro.isAggro) 
        {
            // Si no está agresivo, restablece la velocidad y la distancia de parada
            navMeshAgent.stoppingDistance = 0;
            navMeshAgent.speed = velocidadNormal;

            // Verifica si el enemigo ha llegado a su destino
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            {
                // Si ha llegado, establece el siguiente punto de destino
                NextPoint();
            }
        }
    }
}
