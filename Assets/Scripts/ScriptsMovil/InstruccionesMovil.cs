using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstruccionesMovil : MonoBehaviour
{
    public Button botonIrAlJuego;
    public Button botonVolver;
    public string Juego;
    public string MenuPrincipal;

    private void Start() {
        // Ocultar el botón Volver si es la primera vez
        if (PlayerPrefs.GetInt("PrimeraVez", 1) == 1)
        {
            botonVolver.gameObject.SetActive(false);
        }
        botonIrAlJuego.onClick.AddListener(IrAlJuego);
        botonVolver.onClick.AddListener(Volver);
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
