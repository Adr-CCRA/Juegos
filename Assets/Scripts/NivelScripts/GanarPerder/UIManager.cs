using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pantallaVictoria;
    public GameObject pantallaDerrota;
    public Text textoEstadisticas;
    public ControladorNivel controladorNivel;
    public Button botonContinuar; // Botón Continuar
    public Button botonReintentar; // Botón Reintentar
    public Temporizador temporizador; // Referencia al temporizador

    private GameObject jugador; // Referencia al objeto del jugador

    private void Start()
    {
        pantallaVictoria.SetActive(false);
        pantallaDerrota.SetActive(false);

        botonContinuar.gameObject.SetActive(true); // Activar el botón Continuar al inicio
        botonReintentar.gameObject.SetActive(false);

        temporizador.DetenerTemporizador(); // Asegurarse de que el temporizador esté detenido al inicio

        // Asignar el evento del botón Continuar
        botonContinuar.onClick.AddListener(IniciarJuego);
        botonReintentar.onClick.AddListener(ReiniciarJuego);

        jugador = GameObject.FindGameObjectWithTag("Player"); // Asumiendo que el jugador tiene el tag "Player"
    }

    private void IniciarJuego()
    {
        botonContinuar.gameObject.SetActive(false);
        pantallaVictoria.SetActive(false); // Asegurarse de que la pantalla de victoria está oculta
        controladorNivel.IniciarNivel(); // Iniciar el nivel sin avanzar
        jugador.GetComponent<PersonajeController>().enabled = true; // Reactivar el controlador del jugador
    }

    public void MostrarPantallaVictoria(int puntaje, float tiempo)
    {
        pantallaVictoria.SetActive(true);
        textoEstadisticas.text = $"Puntaje: {puntaje}\nTiempo: {tiempo:0.00} segundos";
        botonContinuar.gameObject.SetActive(true);
        jugador.GetComponent<PersonajeController>().enabled = false; // Desactivar el controlador del jugador
        temporizador.DetenerTemporizador(); // Detener el temporizador
    }

    public void MostrarPantallaDerrota(int puntaje, float tiempo)
    {
        pantallaDerrota.SetActive(true);
        textoEstadisticas.text = $"Puntaje: {puntaje}\nTiempo: {tiempo:0.00} segundos";
        botonReintentar.gameObject.SetActive(true);
        jugador.GetComponent<PersonajeController>().enabled = false; // Desactivar el controlador del jugador
        temporizador.DetenerTemporizador(); // Detener el temporizador
    }

    public void ReiniciarJuego()
    {
        pantallaDerrota.SetActive(false);
        botonReintentar.gameObject.SetActive(false);
        controladorNivel.ReiniciarNivel();
        temporizador.IniciarTemporizador(); // Reiniciar el temporizador
        jugador.GetComponent<PersonajeController>().enabled = true; // Reactivar el controlador del jugador
    }

    public void BotonContinuar()
    {
        pantallaVictoria.SetActive(false);
        botonContinuar.gameObject.SetActive(false);
        controladorNivel.AvanzarNivel(); // Avanzar el nivel
        temporizador.IniciarTemporizador(); // Iniciar el temporizador
        jugador.GetComponent<PersonajeController>().enabled = true; // Reactivar el controlador del jugador
    }
}
