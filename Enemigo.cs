using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float health = 2; // Vida inicial del enemigo
    public GameObject gunHit; // Efecto visual al recibir daño
    public GameObject destroy; // Efecto visual al morir
    void Update()
    {
        EnemieDead(); // Verifica si el enemigo está muerto
    }

    public void Damage(float damage) // Método para aplicar daño al enemigo
    {
        health -= damage; // Reduce la vida del enemigo por la cantidad de daño recibido
        GameObject gunShotEffect = Instantiate(gunHit, transform.position, transform.rotation); // Instancia el efecto de disparo en la posición y rotación del enemigo
        Destroy(gunShotEffect, 0.5f);  // Destruye el efecto de disparo después de 0.5 segundos
    }

    public void EnemieDead() // Método para verificar si el enemigo está muerto
    {
        if (health <= 0) // Verifica si la vida del enemigo es menor o igual a 0
        {
            GameObject destroyEffect = Instantiate(destroy, transform.position, transform.rotation); // Instancia el efecto de destrucción en la posición y rotación del enemigo
            EnemyManager.instance.RemoveEnemy(this); // Elimina al enemigo de la lista de enemigos en el EnemyManager
            Destroy(gameObject); // Destruye el objeto del enemigo
        }
    }
}
