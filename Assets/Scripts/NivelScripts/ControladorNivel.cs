using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNivel : MonoBehaviour
{
    public VerificadorDeBasura verificadorDeBasura;
    public int puntosParaPasar = 51;
    public PuertaController puertaCuarto;
    // public PuertaController puertaPrincipal;

    private int nivelActual = 1;

    private void Start()
    {
        verificadorDeBasura.onVerificacionCompletada.AddListener(VerificarResultado);
    }

    private void VerificarResultado(string mensaje)
    {
        int puntaje = CalcularPuntajeTotal();
        if (puntaje >= puntosParaPasar)
        {
            if (nivelActual == 1)
            {
                puertaCuarto.puedeInteractuar = true; // Habilitar la interacción
            }
            else if (nivelActual == 2)
            {
                // puertaPrincipal.puedeInteractuar = true; // Habilitar la interacción
            }
        }
    }

    private int CalcularPuntajeTotal()
    {
        int puntajeTotal = 0;
        foreach (var resultado in verificadorDeBasura.resultados.Values)
        {
            puntajeTotal += resultado.puntaje;
        }
        return puntajeTotal;
    }

    public void AvanzarNivel()
    {
        if (nivelActual == 1)
        {
            nivelActual = 2;
            verificadorDeBasura.ActualizarNivel(2);
        }
        else if (nivelActual == 2)
        {
            Debug.Log("¡Juego completado!");
        }
    }
}
