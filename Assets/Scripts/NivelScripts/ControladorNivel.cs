using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNivel : MonoBehaviour
{
    public VerificadorDeBasura verificadorDeBasura;
    public Temporizador temporizador;
    public int puntosParaPasar = 51;
    public PuertaController puertaCuarto;
    public PuertaController puertaPrincipal;
    public UIManager uiManager;
    public GameObject cajasNivel1;
    public GameObject cajasNivel2;

    private int nivelActual = 1;
    private bool nivelCompletado = false;
    private int puntajeTotalNivel1 = 0;

    private void Start()
    {
        verificadorDeBasura.onVerificacionCompletada.AddListener(VerificarResultado);
        temporizador.DetenerTemporizador();
        ActivarCajasNivel(1);
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
                Debug.Log("Nivel 1 completado");
                puertaCuarto.puedeInteractuar = true;
                puertaCuarto.puertaAbierta = true;
                puntajeTotalNivel1 = puntaje; // Guardar el puntaje del nivel 1
            }
            else if (nivelActual == 2)
            {
                Debug.Log("Nivel 2 completado");
                puertaPrincipal.puedeInteractuar = true;
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
        int cantidadTipos = verificadorDeBasura.resultados.Count;

        if (cantidadTipos == 0) return 0; // Evitar división por cero

        foreach (var resultado in verificadorDeBasura.resultados.Values)
        {
            puntajeTotal += resultado.puntaje;
        }

        return puntajeTotal / cantidadTipos; // Calcular el promedio de los puntajes
    }

    public void AvanzarNivel()
    {
        if (nivelCompletado)
        {
            if (nivelActual == 1)
            {
                nivelActual = 2;
                verificadorDeBasura.ActualizarNivel(2);
                nivelCompletado = false;
                ReiniciarPuntajeYTiempo();
                ActivarCajasNivel(2);
            }
            else if (nivelActual == 2)
            {
                Debug.Log("¡Juego completado!");
            }
        }
    }

    private void ReiniciarPuntajeYTiempo()
    {
        verificadorDeBasura.resultados.Clear();
        temporizador.ReiniciarTemporizador();
    }

    private void ActivarCajasNivel(int nivel)
    {
        cajasNivel1.SetActive(nivel == 1);
        cajasNivel2.SetActive(nivel == 2);
    }

    public void IniciarNivel()
    {
        nivelCompletado = false;
        temporizador.IniciarTemporizador();
    }

    public void ReiniciarNivel()
    {
        nivelCompletado = false;
        verificadorDeBasura.ActualizarNivel(nivelActual);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        temporizador.IniciarTemporizador();
    }
}
