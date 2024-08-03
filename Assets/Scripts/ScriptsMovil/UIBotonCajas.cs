using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBotonCajas : MonoBehaviour
{
    public Button botonCaja;
    public GameObject imagenCajaCerrada;
    public GameObject imagenCajaAbierta;
    public Interactor interactor;
    public InventarioUIController inventarioUIController; // Referencia al controlador de inventario
    private bool cajaEstaAbierta = false;
    public List<TapaBasureroController> tapaBasureros;

    private void Start()
    {
        if (botonCaja != null)
        {
            botonCaja.onClick.AddListener(OnBotonCajaClick);
        }
        else
        {
            Debug.LogError("El botón de caja no está asignado en el inspector.");
        }

        ActualizarEstadoCaja(false); // Inicializar el estado de las imágenes
    }

    private void OnBotonCajaClick()
    {
        Debug.Log("Botón de caja clicado.");
        if (cajaEstaAbierta)
        {
            if (inventarioUIController != null)
            {
                inventarioUIController.CerrarInventario();
                foreach (var tapa in tapaBasureros)
                {
                    tapa.CerrarTapa();
                }
                ActualizarEstadoCaja(false);
            }
            else
            {
                Debug.LogError("El script InventarioUIController no está asignado en el inspector.");
            }
        }
        else
        {
            if (interactor != null)
            {
                interactor.InteractuarConCaja();
                /*foreach (var tapa in tapaBasureros)
                {
                    tapa.AbrirTapa();
                }*/
                ActualizarEstadoCaja(true);
            }
            else
            {
                Debug.LogError("El script Interactor no está asignado en el inspector.");
            }
        }
    }

    public void ActualizarEstadoCaja(bool estaAbierta)
    {
        cajaEstaAbierta = estaAbierta;
        imagenCajaCerrada.SetActive(!cajaEstaAbierta);
        imagenCajaAbierta.SetActive(estaAbierta);
    }
}
