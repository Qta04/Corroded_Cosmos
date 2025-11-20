using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Instancia de AudioManager
    private AudioSource audioSource; // Componente AudioSource para reproducir sonidos

    [Header("Audio Clips")]
    public AudioClip enemyDamage; // Sonido de daño al enemigo
    public AudioClip enemyDead; // Sonido de enemigo muerto
    public AudioClip doorOpen; // Sonido de puerta abierta
    public AudioClip doorClose; // Sonido de puerta cerrada
    public AudioClip item; // Sonido de recoger un ítem
    public AudioClip armor; // Sonido de recoger armadura
    public AudioClip playerDamage; // Sonido de daño al jugador
    private void Awake()
    {
        // Verifica si no hay otra instancia de AudioManager
        if (instance == null)
        {
            instance = this; // Asigna la instancia actual
        }
    }

    // Métodos públicos para reproducir sonidos específicos
    public void PlayEnemyDamage() { PlaySound(enemyDamage); } // Reproduce el sonido de daño al enemigo
    public void PlayEnemyDead() { PlaySound(enemyDead); } // Reproduce el sonido de enemigo muerto
    public void PlayDoorOpen() { PlaySound(doorOpen); } // Reproduce el sonido de puerta abierta
    public void PlayDoorClose() { PlaySound(doorClose); } // Reproduce el sonido de puerta cerrada
    public void PlayItem() { PlaySound(item); } // Reproduce el sonido de recoger un ítem
    public void PlayArmor() { PlaySound(armor); } // Reproduce el sonido de recoger armadura
    public void PlayPlayerDamage() { PlaySound(playerDamage); } // Reproduce el sonido de daño al jugador

    private void Start()
    {
        // Obtiene el componente AudioSource del GameObject
        audioSource = GetComponent<AudioSource>();
    }
    private void PlaySound(AudioClip clip)
    {
        // Reproduce el clip de audio una vez
        audioSource.PlayOneShot(clip);
    }
}
