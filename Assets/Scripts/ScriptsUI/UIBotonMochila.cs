using UnityEngine;
using UnityEngine.UI;

public class UIBotonMochila : MonoBehaviour
{
    public Button botonMochila;
    public GameObject imagenMochilaCerrada;
    public GameObject imagenMochilaAbierta;
    public InventarioUIController inventarioUIController;
    public PersonajeTitularInventario personajeTitularInventario;

    private bool mochilaAbierta = false;

    private void Start()
    {
        botonMochila.onClick.AddListener(OnBotonMochilaClick);
        ActualizarEstadoMochila();
    }

    private void OnBotonMochilaClick()
    {
        if (mochilaAbierta)
        {
            inventarioUIController.CerrarMochila();
            mochilaAbierta = false;
        }
        else
        {
            personajeTitularInventario.AbrirMochila();
            mochilaAbierta = true;
        }

        ActualizarEstadoMochila();
    }

    private void ActualizarEstadoMochila()
    {
        imagenMochilaCerrada.SetActive(!mochilaAbierta);
        imagenMochilaAbierta.SetActive(mochilaAbierta);
    }
}
