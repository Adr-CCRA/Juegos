using UnityEngine;
using UnityEngine.UI;

public class UIBotonPuerta : MonoBehaviour
{
    public Button botonPuerta;
    public GameObject imagenPuertaCerrada;
    public GameObject imagenPuertaAbierta;
    public PuertaSeleccionada puertaSeleccionada;
    private bool puertaEstaAbierta = false;

    private void Start()
    {
        if (botonPuerta != null)
        {
            botonPuerta.onClick.AddListener(OnBotonPuertaClick);
            Debug.Log("Botón de puerta asignado y listener agregado.");
        }
        else
        {
            Debug.LogError("El botón de puerta no está asignado en el inspector.");
        }

        ActualizarEstadoPuerta(false); // Inicializar el estado de las imágenes
    }

    private void OnEnable()
    {
        if (puertaSeleccionada != null)
        {
            puertaSeleccionada.uiBotonPuerta = this;
        }
    }

    private void OnDisable()
    {
        if (puertaSeleccionada != null)
        {
            puertaSeleccionada.uiBotonPuerta = null;
        }
    }

    private void OnBotonPuertaClick()
    {
        Debug.Log("Botón de puerta clicado.");
        if (puertaSeleccionada != null)
        {
            puertaSeleccionada.InteractuarPuerta();
        }
        else
        {
            Debug.LogError("El script PuertaSeleccionada no está asignado en el inspector.");
        }
    }

    public void ActualizarEstadoPuerta(bool estaAbierta)
    {
        puertaEstaAbierta = estaAbierta;
        imagenPuertaCerrada.SetActive(!estaAbierta);
        imagenPuertaAbierta.SetActive(estaAbierta);
    }
}
