using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levitar : MonoBehaviour
{
    // Variables editables desde el Inspector
    public float floatHeight = 0.5f; // Altura de flotación
    public float floatSpeed = 2f;     // Velocidad de flotación
    public float rotationSpeed = 100f; // Velocidad de rotación

    private Vector3 startPosition;

    void Start()
    {
        // Guardar la posición inicial de la moneda
        startPosition = transform.position;
    }

    void Update()
    {
        // Flotar hacia arriba y hacia abajo
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = startPosition + new Vector3(0, newY, 0);

        // Rotar la moneda
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
