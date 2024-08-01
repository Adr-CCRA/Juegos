using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdministradorMenuPausa : MonoBehaviour
{
  public GameObject ObjetoMenuPausa;
  public bool pausa = false;
  public GameObject MenuSalir;
  public GameObject MenuPartida;
  public Button botonPausa;
  public List<GameObject> imagenesDeFondo;
  private int indiceImagenActual = 0;
  void Start()
  {
    ObjetoMenuPausa.SetActive(false);
    MenuSalir.SetActive(false);
    MenuPartida.SetActive(false);
    botonPausa.onClick.AddListener(Pausa);
    DesactivarTodasLasImagenes();
  }
  void Update()
  {
    if (Keyboard.current.pKey.wasPressedThisFrame)
    {
      Pausa();
    }
  }
  public void Pausa()
  {
    if (pausa == false)
    {
      ObjetoMenuPausa.SetActive(true);
      pausa = true;

      Time.timeScale = 0;
      CambiarImagenDeFondo();
    }
  }
  public void Reanudar()
  {
    ObjetoMenuPausa.SetActive(false);
    pausa = false;
    Time.timeScale = 1;
    MenuSalir.SetActive(false);
    MenuPartida.SetActive(false);
    DesactivarTodasLasImagenes();
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
  private void CambiarImagenDeFondo()
  {
    DesactivarTodasLasImagenes(); // Desactiva la imagen actual
    if (imagenesDeFondo.Count > 0)
    {
      imagenesDeFondo[indiceImagenActual].SetActive(true); // Activa la siguiente imagen
      indiceImagenActual = (indiceImagenActual + 1) % imagenesDeFondo.Count; // Pasar a la siguiente imagen
    }
  }

  private void DesactivarTodasLasImagenes()
  {
    foreach (var imagen in imagenesDeFondo)
    {
      imagen.SetActive(false);
    }
  }
}
