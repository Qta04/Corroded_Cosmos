using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

[CreateAssetMenu (fileName = "New Gun", menuName = "Gun/New Gun")]
public class Guns : ScriptableObject
{
    [SerializeField] private float range; // Rango de disparo del arma
    [SerializeField] private float verticalRange; // Rango vertical del arma
    [SerializeField] private int horizontalRange; // Rango horizontal del arma
    [SerializeField] private float fireRate; // Tasa de disparo del arma
    [SerializeField] private int damage; // Daño que inflige el arma
    [SerializeField] private GameObject arma; // Prefab del arma
    [SerializeField] private AudioClip sound; // Sonido del disparo del arma

    // Propiedades para acceder y modificar los campos privados
    public float Range { get => range; set => range = value; } // Propiedad para el rango
    public float VerticalRange { get => verticalRange; set => verticalRange = value; } // Propiedad para el rango vertical
    public int HorizontalRange { get => horizontalRange; set => horizontalRange = value; } // Propiedad para el rango horizontal
    public float FireRate { get => fireRate; set => fireRate = value; } // Propiedad para la tasa de disparo
    public int Damage { get => damage; set => damage = value; } // Propiedad para el daño
    public AudioClip Sound { get => sound; set => sound = value; } // Propiedad para el sonido
    public GameObject Arma { get => arma; set => arma = value; } // Propiedad para el prefab del arma
}
