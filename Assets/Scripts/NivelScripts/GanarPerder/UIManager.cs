using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pantallaVictoria;
    public GameObject pantallaDerrota;
    public Text textoEstadisticas;
    public Text textoDerrotaEstad;
    public Text textoNivel;
    public ControladorNivel controladorNivel;
    public Button botonContinuar; // Botón Continuar
    public Button botonReintentar; // Botón Reintentar
    public Temporizador temporizador; // Referencia al temporizador

    private GameObject jugador; // Referencia al objeto del jugador
    private int  nivelActual;

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
        jugador.GetComponent<PersonajeController>().enabled = false;
    }

    private void Update() {
        nivelActual = AdministradorGuardarJuego.dato.nivelActual;
        textoNivel.text =$"Nivel: 1-{nivelActual}";
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
        float finTiempo = temporizador.tiempoLimite - tiempo;
        int minutos = Mathf.FloorToInt(finTiempo / 60F);
        int segundos = Mathf.FloorToInt(finTiempo % 60F);
        string tiempoFinalizado = string.Format("{0:00}:{1:00}", minutos, segundos);
        pantallaVictoria.SetActive(true);
        pantallaDerrota.SetActive(false);
        textoEstadisticas.text = $"Nivel: {nivelActual}\nPuntaje: {puntaje}\nTiempo: {tiempoFinalizado}";
        botonContinuar.gameObject.SetActive(true);
        jugador.GetComponent<PersonajeController>().enabled = false; // Desactivar el controlador del jugador
        temporizador.DetenerTemporizador(); // Detener el temporizador
        AudioController.Instancia.musicaSource.Pause();
        AudioController.Instancia.PlayEfecto("Ganaste");
    }

    public void MostrarPantallaDerrota(int puntaje, float tiempo)
    {
        float finTiempo = temporizador.tiempoLimite- tiempo;
        int minutos = Mathf.FloorToInt(finTiempo / 60F);
        int segundos = Mathf.FloorToInt(finTiempo % 60F);
        string tiempoFinalizado = string.Format("{0:00}:{1:00}", minutos, segundos);
        pantallaDerrota.SetActive(true);
        textoDerrotaEstad.text = $"Nivel: {nivelActual}\nPuntaje: {puntaje}\nTiempo: {tiempoFinalizado}";
        botonReintentar.gameObject.SetActive(true);
        jugador.GetComponent<PersonajeController>().enabled = false; // Desactivar el controlador del jugador
        temporizador.DetenerTemporizador(); // Detener el temporizador
        AudioController.Instancia.musicaSource.Stop();
        AudioController.Instancia.PlayEfecto("Perdiste");
    }

    public void ReiniciarJuego()
    {
        pantallaDerrota.SetActive(false);
        pantallaVictoria.SetActive(false);
        botonReintentar.gameObject.SetActive(false);
        controladorNivel.ReiniciarNivel();
        temporizador.IniciarTemporizador(); // Reiniciar el temporizador
        jugador.GetComponent<PersonajeController>().enabled = true; // Reactivar el controlador del jugador
    }

    public void BotonContinuar()
    {
        pantallaVictoria.SetActive(false);
        pantallaDerrota.SetActive(false);
        botonContinuar.gameObject.SetActive(false);
        botonReintentar.gameObject.SetActive(false);
        controladorNivel.AvanzarNivel(); // Avanzar el nivel
        temporizador.IniciarTemporizador(); // Iniciar el temporizador
        jugador.GetComponent<PersonajeController>().enabled = true; // Reactivar el controlador del jugador
        AudioController.Instancia.musicaSource.Play();
    }
}
