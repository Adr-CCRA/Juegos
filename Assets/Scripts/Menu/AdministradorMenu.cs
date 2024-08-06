using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;

public class AdministradorMenu : MonoBehaviour
{
  // public Button botonContinuar;
  public string nombreNivel = "SampleScene"; // Nombre de la escena del juego
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

  /*public void ContinuarJuego()
  {
    SceneManager.LoadScene(nombreNivel);
  }  */

}
