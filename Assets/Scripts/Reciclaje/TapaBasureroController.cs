using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TapaBasureroController : MonoBehaviour
{
    public bool tapaAbierta = false;
    public float anguloApertura; // El ángulo que queremos que la tapa gire
    public float velocidadRotacionTapa = 3.0f;

    private float yInicial;
    private float xInicial;
    private float zInicial;

    public AudioClip abrirTapa;
    public AudioClip cerrarTapa;

    public bool puedeInteractuar = true; // Variable para habilitar/deshabilitar la interacción

    void Start()
    {
        yInicial = transform.localEulerAngles.y;
        xInicial = transform.localEulerAngles.x;
        zInicial = transform.localEulerAngles.z;
    }

    void Update()
    {
        float xDestino = tapaAbierta ? xInicial + anguloApertura : xInicial;
        Quaternion rotacionDestino = Quaternion.Euler(xDestino, yInicial, zInicial);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotacionDestino, velocidadRotacionTapa * Time.deltaTime);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            CerrarTapa();
        }
    }

    public void AbrirTapa()
    {
        if (!puedeInteractuar || tapaAbierta) return;
        tapaAbierta = true;
        AudioController.Instancia.PlayEfecto("AbrirPuerta");
    }

    public void CerrarTapa()
    {
        if (!puedeInteractuar || !tapaAbierta) return;
        tapaAbierta = false;
        AudioController.Instancia.PlayEfecto("AbrirPuerta");
    }
}
