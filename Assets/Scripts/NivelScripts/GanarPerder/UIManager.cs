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

    private void Start()
    {
        pantallaVictoria.SetActive(false);
        pantallaDerrota.SetActive(false);

        botonContinuar.gameObject.SetActive(true); // Activar el botón Continuar al inicio
        botonReintentar.gameObject.SetActive(false);

        temporizador.DetenerTemporizador(); // Asegurarse de que el temporizador esté detenido al inicio

        // Asignar el evento del botón Continuar
        botonContinuar.onClick.AddListener(BotonContinuar);
        botonReintentar.onClick.AddListener(BotonReintentar);
    }

    public void MostrarPantallaVictoria(int puntaje, float tiempo)
    {
        pantallaVictoria.SetActive(true);
        textoEstadisticas.text = $"Puntaje: {puntaje}\nTiempo: {tiempo:0.00} segundos";

        botonContinuar.gameObject.SetActive(true);
    }

    public void MostrarPantallaDerrota(int puntaje, float tiempo)
    {
        pantallaDerrota.SetActive(true);
        textoEstadisticas.text = $"Puntaje: {puntaje}\nTiempo: {tiempo:0.00} segundos";

        botonReintentar.gameObject.SetActive(true);
    }

    public void BotonReintentar()
    {
        pantallaDerrota.SetActive(false);
        botonReintentar.gameObject.SetActive(false);
        controladorNivel.ReiniciarNivel();
        temporizador.IniciarTemporizador(); // Reiniciar el temporizador
    }

    public void BotonContinuar()
    {
        pantallaVictoria.SetActive(false);
        botonContinuar.gameObject.SetActive(false);
        controladorNivel.AvanzarNivel();
        temporizador.IniciarTemporizador(); // Iniciar el temporizador
    }
}
