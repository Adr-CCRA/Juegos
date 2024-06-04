using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class AdministradorMenuPausa : MonoBehaviour
{
  public GameObject ObjetoMenuPausa;
  public bool pausa = false;
  public GameObject MenuSalir;
  void Start()
  {
    ObjetoMenuPausa.SetActive(false);
    MenuSalir.SetActive(false);
  }
  void Update()
  {
    if(Keyboard.current.pKey.wasPressedThisFrame)
    {
      if(pausa == false)
      {
        ObjetoMenuPausa.SetActive(true);
        pausa = true;

        Time.timeScale = 0;
      }
    }
  }
  public void Reanudar()
  {
    ObjetoMenuPausa.SetActive(false);
    pausa = false;
    Time.timeScale = 1;
    MenuSalir.SetActive(false);
  }

  public void IrMenu(string MenuPrincipal)
  {
    SceneManager.LoadScene(MenuPrincipal);
    Reanudar();
  }

  public void SalirJuego()
  {
    Application.Quit();
    Debug.Log("Salio del Juego");
  }
}
