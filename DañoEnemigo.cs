using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoEnemigo : MonoBehaviour
{
    public static DañoEnemigo instance; // Instancia estática de DañoEnemigo para acceso global
    public bool isDamaging; // Variable que almacena si se está recibiendo daño o no
    [Header("Damage per enemy")]
    public int damageAmountEnemy1 = 10; // Daño infligido por el enemigo 
    public float timeBetweenDamage = 1.5f; // Intervalo de tiempo entre cada daño
    private float damageCounter; // Contador para gestionar el tiempo entre daño
    private void Awake()
    {
        // Verifica si no hay otra instancia de DañoEnemigo
        if (instance == null)
        {
            instance = this; // Asigna la instancia actual
        }
    }
    void Start()
    {
        damageCounter = timeBetweenDamage; // Inicializa el contador de daño con el tiempo entre daño
    }

    void Update()
    {
        DamagePerTime(); // Llama al método para gestionar el daño por tiempo
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Verifica si el objeto que colisiona tiene la etiqueta "Enemy"
        {
            damageCounter = timeBetweenDamage; // Reinicia el contador de daño al entrar en el objeto
            isDamaging = true; // Indica que se está haciendo daño
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy")) // Verifica si el objeto que salió tiene la etiqueta "Enemy"
        {
            isDamaging = false; // Indica que se deja de hacer daño
        }
    }

    public void DamagePerTime() // Método que analiza si se hace daño o no respecto del tiempo
    {
        if (isDamaging) // Verifica si se está haciendo daño
        {
            if (damageCounter >= timeBetweenDamage) // Verifica si el contador ha alcanzado el tiempo entre daño
            {
                AudioManager.instance.PlayPlayerDamage(); // Reproduce el sonido de daño al jugador
                VidaJugador.Instance.PlayerDamage(damageAmountEnemy1); // Inflige daño al jugador
                UIManager.Instance.HealthText(VidaJugador.Instance.health); // Actualiza el texto de salud en la interfaz de usuario
                damageCounter = 0; // Reinicia el contador de daño
            }
            damageCounter += Time.deltaTime; // Incrementa el contador de daño con el tiempo transcurrido
        }
        else
        {
            damageCounter = 0; // Reinicia el contador si no se está haciendo daño
        }
    }
}
