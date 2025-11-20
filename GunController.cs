using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GunController : MonoBehaviour
{
    public static GunController instance; // Instancia estática para acceso global
    private BoxCollider gunTrigger; // Collider que actúa como trigger para el arma
    public Guns gun; // Referencia al objeto de tipo Guns
    private PlayerInput playerInput; // Componente para manejar la entrada del jugador
    private CambioArma cambioArma; // Componente para cambiar de arma
    public LayerMask raycastLayerMask; // Máscara de capas para el raycast
    private bool canFire; // Indica si se puede disparar
    private float nextTimeToFire; // Tiempo para el siguiente disparo
    public AudioSource audioSource; // Fuente de audio para los sonidos del arma
    public GameObject efectoFuego; // Efecto visual de disparo
    private int currentAmmo; // Contador de balas actuales
    public int maxAmmo = 10; // Número máximo de balas
    public GameObject UIbalas; // Texto para mostrar el estado de las balas
    public TextMeshProUGUI contadorBalas; // Texto para mostrar el conteo de balas

    // Método llamado al iniciar el script
    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Asigna la instancia actual
        }

        gunTrigger = GetComponent<BoxCollider>(); // Obtiene el BoxCollider del objeto
        SetTriggers(); // Configura los triggers del arma
    }

    // Método llamado una vez por frame
    void Update()
    {
        // Actualiza el texto del contador de balas
        contadorBalas.text = currentAmmo + "/" + maxAmmo;
    }

    // Método llamado al iniciar
    void Start()
    {
        playerInput = GetComponent<PlayerInput>(); // Obtiene el componente PlayerInput
        canFire = true; // Permite disparar al inicio
        cambioArma = GetComponent<CambioArma>(); // Obtiene la referencia al cambio de arma
        currentAmmo = maxAmmo; // Inicializa las balas disponibles
    }

    // Coroutine que controla el tiempo entre disparos
    IEnumerator CanFire(float time)
    {
        canFire = false; // Desactiva el disparo
        yield return new WaitForSeconds(time); // Espera el tiempo especificado
        canFire = true; // Reactiva el disparo
    }

    // Coroutine que resetea el efecto de disparo
    IEnumerator ResetEfecto()
    {
        yield return new WaitForSeconds(0.5f); // Espera 0.5 segundos
        efectoFuego.SetActive(false); // Desactiva el efecto de fuego
    }

    // Método que configura el tamaño y la posición del collider del arma
    public void SetTriggers()
    {
        gunTrigger.size = new Vector3(gun.HorizontalRange, gun.VerticalRange, gun.Range); // Establece el tamaño del collider
        gunTrigger.center = new Vector3(0, 0, gun.Range * 0.5f); // Establece la posición del collider
    }

    public void Fire(InputAction.CallbackContext context)
{
    // Verifica si se ha realizado la acción de disparo, si se puede disparar y si hay munición disponible
    if (context.performed && canFire && currentAmmo > 0)
    {
        UIbalas.SetActive(false);
        // Reproduce el sonido del disparo
        audioSource.PlayOneShot(gun.Sound);
        // Activa el efecto visual de disparo
        efectoFuego.SetActive(true);
        StartCoroutine(ResetEfecto()); // Inicia la coroutine para resetear el efecto de disparo

        // Recorre todos los enemigos en rango
        foreach (Enemigo enemigo in EnemyManager.instance.enemiesInRange)
        {
            // Calcula la dirección hacia el enemigo
            var dir = (enemigo.transform.position - transform.position).normalized;
            RaycastHit hit; // Variable para almacenar información del raycast

            // Realiza un raycast hacia el enemigo
            if (Physics.Raycast(transform.position, dir, out hit, gun.Range * 1.5f, raycastLayerMask))
            {
                // Verifica si el raycast impactó al enemigo
                if (hit.transform == enemigo.transform)
                {
                    enemigo.Damage(gun.Damage); // Aplica daño al enemigo
                }
            }
            // Dibuja una línea verde en el editor para visualizar el raycast
            Debug.DrawRay(transform.position, dir * gun.Range, Color.green, 1f);
        }

        currentAmmo--; // Disminuye el conteo de balas
        StartCoroutine(CanFire(gun.FireRate)); // Inicia la coroutine para controlar el tiempo entre disparos
    }
    else if (currentAmmo <= 0)
    {
        // Muestra un mensaje si no hay balas disponibles
        UIbalas.SetActive(true);
    }
}

// Método para recargar balas
public void Reload(int ammoAmount)
{
    currentAmmo += ammoAmount; // Aumenta el conteo de balas
    if (currentAmmo > maxAmmo)
    {
        currentAmmo = maxAmmo; // Asegúrate de no exceder el máximo
    }
    // Actualiza el texto del contador de balas
    contadorBalas.text = currentAmmo + " / " + maxAmmo;
}

// Método para actualizar el arma actual
public void UpdateGun(Guns newGun)
{
    gun = newGun; // Actualiza la referencia al nuevo objeto de arma
    SetTriggers(); // Actualiza los triggers con las nuevas variables del arma
}

// Método llamado cuando otro collider entra en el trigger
private void OnTriggerEnter(Collider other)
{
    // Verifica si el objeto que colisiona es un arma
    if (other.CompareTag("Weapon"))
    {
        // Obtén el componente recogidaArma del objeto recogido
        recogidaArma gunPickup = other.GetComponent<recogidaArma>();
        if (gunPickup != null)
        {
            // Llama al método para recoger el arma y pasa la nueva arma
            cambioArma.PickUpWeapon(gunPickup.gun);
        }
        // Destruye el objeto del arma recogida
        Destroy(other.gameObject);
    }

    // Verifica si el objeto que colisiona es un enemigo
    Enemigo enemigo = other.transform.GetComponent<Enemigo>();
    if (enemigo)
    {
        // Añade el enemigo al gestor de enemigos
        EnemyManager.instance.AddEnemy(enemigo);
    }
}

// Método llamado cuando otro collider sale del trigger
private void OnTriggerExit(Collider other)
{
    // Verifica si el objeto que salió es un enemigo
    Enemigo enemigo = other.transform.GetComponent<Enemigo>();
    if (enemigo)
    {
        // Elimina el enemigo del gestor de enemigos
        EnemyManager.instance.RemoveEnemy(enemigo);
    }
}

}
