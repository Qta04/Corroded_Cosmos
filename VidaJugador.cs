using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class VidaJugador : MonoBehaviour
{
    public static VidaJugador Instance; // Instancia estática para el patrón Singleton
    public int maxHealth; // Salud máxima del jugador
    public int health; // Salud actual del jugador
    public int maxEscudo; // Escudo máximo del jugador
    public int duraEscudo; // Durabilidad actual del escudo
    public TextMeshProUGUI uiescudo; // Texto para mostrar la durabilidad del escudo en la interfaz

    private void Awake()
    {
        // Implementación del patrón Singleton
        if (Instance == null)
        {
            Instance = this; // Asigna la instancia actual
        }
        else
        {
            Destroy(gameObject); // Destruye el objeto si ya existe una instancia
        }
    }

    private void Start()
    {
        health = maxHealth; // Inicializa la salud actual al máximo
        duraEscudo = maxEscudo; // Inicializa la durabilidad del escudo al máximo
    }

    private void Update()
    {
        uiescudo.text = duraEscudo + " %"; // Actualiza el texto de la durabilidad del escudo
    }

    // Método para aplicar daño al jugador
    public void PlayerDamage(int damage)
    {
        if (duraEscudo > 0) // Verifica si hay escudo disponible
        {
            duraEscudo -= damage; // Reduce la durabilidad del escudo
            if (duraEscudo < 0) // Si el escudo se agota
            {
                health += duraEscudo; // Aplica el daño restante a la salud
                duraEscudo = 0; // Asegura que la durabilidad del escudo no sea negativa
            }
        }
        else
        {
            health -= damage; // Aplica el daño directamente a la salud
        }

        // Verifica si la salud ha llegado a 0 o menos
        UIManager.Instance.GameOver(health); // Llama al método GameOver en UIManager
    }

    // Método para curar al jugador
    public void Curacion(int cura)
    {
        if ((health + cura) > maxHealth) // Verifica si la curación excede la salud máxima
        {
            health = maxHealth; // Establece la salud al máximo
        }
        else
        {
            health += cura; // Aumenta la salud
        }
        UIManager.Instance.HealthText(health); // Actualiza el texto de salud en la interfaz
    }

    // Método para aumentar la durabilidad del escudo
    public void Escudo(int escudo)
    {
        if ((duraEscudo + escudo) > maxEscudo) // Verifica si el escudo excede el máximo
        {
            duraEscudo = maxEscudo; // Establece la durabilidad al máximo
        }
        else
        {
            duraEscudo += escudo; // Aumenta la durabilidad del escudo
        }
    }
}
