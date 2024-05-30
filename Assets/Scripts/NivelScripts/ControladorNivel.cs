using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNivel : MonoBehaviour
{
    public VerificadorDeBasura verificadorDeBasura;
    public Temporizador temporizador;
    public int puntosParaPasar = 51;
    public PuertaController puertaCuarto;
    // public PuertaController puertaPrincipal;
    public UIManager uiManager; // Añadido: referencia al UIManager

    private int nivelActual = 1;

    private void Start()
    {
        verificadorDeBasura.onVerificacionCompletada.AddListener(VerificarResultado);
        temporizador.DetenerTemporizador();
    }

    private void VerificarResultado(string mensaje)
    {
        int puntaje = CalcularPuntajeTotal();
        float tiempo = temporizador.ObtenerTiempo();
        if (puntaje >= puntosParaPasar)
        {
            uiManager.MostrarPantallaVictoria(puntaje, tiempo);
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
            temporizador.IniciarTemporizador(); // Reiniciar el temporizador para el nuevo nivel
        }
        else if (nivelActual == 2)
        {
            Debug.Log("¡Juego completado!");
        }
    }

    public void TiempoAgotado()
    {
        int puntaje = CalcularPuntajeTotal();
        float tiempo = temporizador.ObtenerTiempo();
        if (puntaje < puntosParaPasar)
        {
            uiManager.MostrarPantallaDerrota(puntaje, tiempo);
        }
    }

    public void ReiniciarNivel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        temporizador.IniciarTemporizador(); // Reiniciar el temporizador
    }
}
