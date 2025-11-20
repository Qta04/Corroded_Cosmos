using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // Instancia estática para el patrón Singleton

    [Header("UI")]
    public TextMeshProUGUI uiText; // Texto para mostrar mensajes al jugador
    public TextMeshProUGUI healthText; // Texto para mostrar la salud del jugador
    public TextMeshProUGUI armorText; // Texto para mostrar la armadura del jugador

    [Header("Game Over")]
    public GameObject gameOverPanel; // Panel que se muestra al finalizar el juego

    private Coroutine activeCoroutine; // Referencia a la coroutine activa

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
        Time.timeScale = 1; // Asegura que el tiempo del juego esté en marcha
        gameOverPanel.SetActive(false); // Oculta el panel de Game Over al inicio
    }

    // Coroutine para mostrar un mensaje temporal
    IEnumerator TextActive(string text)
    {
        uiText.text = "Picked up a " + text; // Muestra el mensaje
        yield return new WaitForSeconds(2f); // Espera 2 segundos
        uiText.text = string.Empty; // Limpia el mensaje
    }

    // Método para iniciar la coroutine de texto
    public void SetUiText(string text)
    {
        StartCoroutine(text); // Inicia la coroutine con el texto proporcionado
    }

    // Método para actualizar el texto de salud
    public void HealthText(int health)
    {
        healthText.text = health + " %"; // Actualiza el texto de salud
    }

    // Método para manejar el estado de Game Over
    public void GameOver(int health)
    {
        if (health <= 0) // Verifica si la salud es 0 o menos
        {
            health = 0; // Asegura que la salud no sea negativa
            gameOverPanel.SetActive(true); // Muestra el panel de Game Over
            Time.timeScale = 0; // Detiene el tiempo del juego
        }
    }

    // Método para actualizar el texto de armadura
    public void ArmorText(float armor)
    {
        armorText.text = armor + " %"; // Actualiza el texto de armadura
    }

    // Método para iniciar la coroutine de texto, asegurando que solo una esté activa a la vez
    public new void StartCoroutine(string text)
    {
        if (activeCoroutine != null)
        {
            StopCoroutine(activeCoroutine); // Detiene la coroutine activa
        }

        activeCoroutine = StartCoroutine(TextActive(text)); // Inicia una nueva coroutine
    }
}
