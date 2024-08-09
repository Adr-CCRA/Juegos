using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
public class InstruccionesController : MonoBehaviour
{
    public List<GameObject> paginasInstrucciones; // Lista de páginas de instrucciones
    public Button botonAtras;
    public Button botonSiguiente;
    public Button botonIrAlJuego;
    public Button botonVolver;
    public string Juego;
    public string MenuPrincipal;

    private int paginaActual = 0;
    public List<VideoPlayer> videoPlayers;
    private int currentVideoIndex = 0;
    void Start()
    {
        // Ocultar el botón Volver si es la primera vez
        if (PlayerPrefs.GetInt("PrimeraVez", 1) == 1)
        {
            botonVolver.gameObject.SetActive(false);
        }

        ActualizarPagina();
        ActualizarVideo();

        botonAtras.onClick.AddListener(Atras);
        botonSiguiente.onClick.AddListener(Siguiente);
        botonIrAlJuego.onClick.AddListener(IrAlJuego);
        botonVolver.onClick.AddListener(Volver);
    }

    void ActualizarPagina()
    {
        for (int i = 0; i < paginasInstrucciones.Count; i++)
        {
            paginasInstrucciones[i].SetActive(i == paginaActual);

            // Si la página está activa, mostrar el video correspondiente.
            if (i == paginaActual)
            {
                currentVideoIndex = i;  // Sincroniza el índice del video con la página actual
                MostrarVideo();
            }
            else
            {
                OcultarVideo();
            }
        }

        // Mostrar u ocultar botones según la página actual
        botonAtras.gameObject.SetActive(paginaActual > 0);
        botonSiguiente.gameObject.SetActive(paginaActual < paginasInstrucciones.Count - 1);
        botonIrAlJuego.gameObject.SetActive(paginaActual == paginasInstrucciones.Count - 1);
    }

    void ActualizarVideo()
    {
        for (int i = 0; i < videoPlayers.Count; i++)
        {
            videoPlayers[i].gameObject.SetActive(i == currentVideoIndex);
        }

        // Mostrar u ocultar botones según la página actual
        botonAtras.gameObject.SetActive(currentVideoIndex > 0);
        botonSiguiente.gameObject.SetActive(currentVideoIndex < videoPlayers.Count - 1);
        botonIrAlJuego.gameObject.SetActive(currentVideoIndex == videoPlayers.Count - 1);
    }
    public void OcultarVideo()
    {
        if (videoPlayers[currentVideoIndex].isPlaying)
        {
            videoPlayers[currentVideoIndex].Stop();
        }
        // videoPlayers[currentVideoIndex].clip = null; // Libera el video de la memoria
        videoPlayers[currentVideoIndex].gameObject.SetActive(false);
    }

    public void MostrarVideo()
    {
        // string videoPath = Application.dataPath + "/Videos/" + videoPlayers[currentVideoIndex].name + ".mp4";
        // videoPlayers[currentVideoIndex].url = videoPath;
        videoPlayers[currentVideoIndex].gameObject.SetActive(true);
        videoPlayers[currentVideoIndex].Play();
        /* string videoPath = Application.dataPath + "/Videos/" + videoPlayers[currentVideoIndex].name + ".mp4";
        Debug.Log("El archivo de video existe: " + videoPath);
        if (System.IO.File.Exists(videoPath))
        {
            videoPlayers[currentVideoIndex].url = videoPath;
            videoPlayers[currentVideoIndex].gameObject.SetActive(true);
            videoPlayers[currentVideoIndex].Play();
        }
        else
        {
            Debug.Log("El archivo de video no existe: " + videoPath);
        } */
    }

    void Atras()
    {
        if (paginaActual > 0)
        {
            paginaActual--;
            ActualizarPagina();
            ActualizarVideo();
        }
    }

    void Siguiente()
    {
        if (paginaActual < paginasInstrucciones.Count - 1)
        {
            paginaActual++;
            ActualizarPagina();
            ActualizarVideo();
        }
    }

    public void IrAlJuego()
    {
        // Marcar como no la primera vez para futuras visitas
        PlayerPrefs.SetInt("PrimeraVez", 0);
        SceneManager.LoadScene(Juego);
    }

    public void Volver()
    {
        SceneManager.LoadScene(MenuPrincipal);
    }
}
