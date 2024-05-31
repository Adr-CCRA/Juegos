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
    private bool nivelCompletado = false;

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
            nivelCompletado = true;
            uiManager.MostrarPantallaVictoria(puntaje, tiempo);
            if (nivelActual == 1)
            {
                Debug.Log("Estoy en nivel 1");
                puertaCuarto.puedeInteractuar = true; // Habilitar la interacción
            }
            else if (nivelActual == 2)
            {
                Debug.Log("Estoy en nivel 2");
                // puertaPrincipal.puedeInteractuar = true; // Habilitar la interacción
            }
        }
        else
        {
            FindObjectOfType<UIManager>().MostrarPantallaDerrota(puntaje, temporizador.ObtenerTiempo());
        }
    }

    public int CalcularPuntajeTotal()
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
        if (nivelCompletado)
        {
            if (nivelActual == 1)
            {
                nivelActual = 2;
                verificadorDeBasura.ActualizarNivel(2);
                nivelCompletado = false; // Resetear el estado de nivel completado
            }
            else if (nivelActual == 2)
            {
                Debug.Log("¡Juego completado!");
            }
        }
    }

    public void IniciarNivel()
    {
        nivelCompletado = false; // Asegurarse de que el nivel no esté marcado como completado al inicio
        temporizador.IniciarTemporizador(); // Iniciar el temporizador
    }

    public void ReiniciarNivel()
    {
        nivelCompletado = false;
        verificadorDeBasura.ActualizarNivel(nivelActual);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        temporizador.IniciarTemporizador();
    }
}
