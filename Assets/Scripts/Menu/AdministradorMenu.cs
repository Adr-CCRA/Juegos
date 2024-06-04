using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdministradorMenu : MonoBehaviour
{
  public void IniciarNivel(string nombreNivel)
  {
    SceneManager.LoadScene(nombreNivel);
  }
  public void Salir()
  {
    Application.Quit();
    Debug.Log("Salio del Juego");
  }
}
