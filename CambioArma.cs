using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioArma : MonoBehaviour
{
    public GameObject armaPrincipal; // Referencia a la arma principal
    public GameObject armaSecundaria; // Referencia a la arma secundaria
    private bool principalActiva = true; // Estado que indica si el arma principal está activa
    private void Start()
    {
        // Se asegura que el arma secundaria este apagada desde el inicio
        armaPrincipal.SetActive(true);
        armaSecundaria.SetActive(false);
    }

    public void SwitchWeapon() // Método para cambiar entre armas
    {
        principalActiva = !principalActiva; // Cambia el estado del arma activa

        // Activa o desactiva las armas según el estado actual
        armaPrincipal.SetActive(principalActiva); // Activa el arma principal si está activa
        armaSecundaria.SetActive(!principalActiva); // Activa el arma secundaria si el arma principal está desactivada
    }

    public void PickUpWeapon(Guns newGun) // Método para recoger una nueva arma
    {
        GunController.instance.UpdateGun(newGun); // Actualiza el GunController con la nueva arma recogida
        AudioManager.instance.PlayItem(); // Reproduce el sonido de recoger un ítem
        // Desactiva el arma principal y activa la secundaria al recoger una nueva arma
        armaPrincipal.SetActive(false);
        armaSecundaria.SetActive(true);
    }
}
