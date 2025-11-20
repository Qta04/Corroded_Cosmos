using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance; // Instancia estática de EnemyManager para acceso global
    public List<Enemigo> enemiesInRange = new List<Enemigo>(); // Lista que almacena los enemigos en rango

    private void Awake()
    {
        // Verifica si no hay otra instancia de EnemyManager
        if (instance == null)
        {
            instance = this; // Asigna la instancia actual
        }
    }

    public void AddEnemy(Enemigo enemy) // Método para añadir un enemigo a la lista
    {
        enemiesInRange.Add(enemy); // Añade el enemigo a la lista
    }

    public void RemoveEnemy(Enemigo enemy) // Método para eliminar un enemigo de la lista
    {
        enemiesInRange.Remove(enemy); // Elimina el enemigo de la lista
    }
}
