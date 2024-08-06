using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdministradorMenu : MonoBehaviour
{
    public string nombreNivel; // Nombre de la escena del juego
    public string nombreInstrucciones; // Nombre de la escena de las instrucciones

    void Start()
    {
        if (PlayerPrefs.GetInt("PrimeraVez", 1) == 1)
        {
            // Primera vez que el jugador ingresa
            PlayerPrefs.SetInt("PrimeraVez", 0);
            IniciarNivel(nombreInstrucciones);
        }
    }

    public void IniciarNivel(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }

    public void Instrucciones(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salio del Juego");
    }
}
