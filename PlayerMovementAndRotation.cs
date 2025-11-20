using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementAndRotation : MonoBehaviour
{
   public static PlayerMovementAndRotation instance; // Instancia estática para acceso global
    private CharacterController cc; // Componente CharacterController para manejar el movimiento
    private PlayerInput playerInput; // Componente para manejar la entrada del jugador
    public float speed; // Velocidad de movimiento del jugador
    public float rotationSpeed; // Velocidad de rotación del jugador
    private Vector2 inputM; // Almacena la entrada del movimiento
    private Vector3 inputVector; // Vector de entrada para el movimiento
    private Vector3 movementVector; // Vector de movimiento final
    private float CharacterGravity = -9.82f; // Gravedad aplicada al jugador
    private float currrentlookingPos; // Posición actual de rotación del jugador
    private float rotationInput; // Entrada de rotación

    public Animator camAnimator; // Referencia al Animator de la cámara
    public bool EstaCaminando; // Indica si el jugador está caminando

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Asigna la instancia actual
        }

        playerInput = GetComponent<PlayerInput>(); // Obtiene el componente PlayerInput
        cc = GetComponent<CharacterController>(); // Obtiene el componente CharacterController
    }
    void Update()
    {
        GetInput(); // Obtiene la entrada del jugador
        Movement(); // Maneja el movimiento del jugador
        RotatePlayer(); // Maneja la rotación del jugador
        AnimacionCamara(); // Actualiza la animación de la cámara

        // Actualiza el parámetro de animación "EstaCaminando"
        camAnimator.SetBool("EstaCaminando", EstaCaminando);
    }

    // Método que obtiene la entrada del jugador
    public void GetInput()
    {
        inputM = playerInput.actions["Move"].ReadValue<Vector2>(); // Lee la entrada de movimiento
        inputVector = new Vector3(0, 0, inputM.y); // Crea un vector de movimiento basado en la entrada
        inputVector = transform.TransformDirection(inputVector); // Convierte el vector a espacio local
        movementVector = (inputVector * speed) + (Vector3.up * CharacterGravity); // Calcula el vector de movimiento final
        rotationInput = inputM.x * rotationSpeed * Time.deltaTime; // Calcula la entrada de rotación
    }

    // Método que maneja el movimiento del jugador
    public void Movement()
    {
        cc.Move(movementVector * Time.deltaTime); // Mueve al jugador usando el CharacterController
    }

    // Método que actualiza el estado de la animación de la cámara
    public void AnimacionCamara()
    {
        // Verifica si hay movimiento
        if (inputM.magnitude > 0.1)
        {
            EstaCaminando = true; // Marca al jugador como caminando
        }
        else
        {
            EstaCaminando = false; // Marca al jugador como no caminando
        }
    }

    // Método que maneja la rotación del jugador
    void RotatePlayer()
    {
        currrentlookingPos += rotationInput; // Actualiza la posición de rotación
        transform.localRotation = Quaternion.AngleAxis(currrentlookingPos, transform.up); // Aplica la rotación al jugador
    }
}
