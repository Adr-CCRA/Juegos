using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DatosElementosMouse : MonoBehaviour
{
  public Image objetoSprite;
  public TextMeshProUGUI objetoContador;

  private void Awake() {
    objetoSprite.color = Color.clear;
    objetoContador.text = "";
  }
}
