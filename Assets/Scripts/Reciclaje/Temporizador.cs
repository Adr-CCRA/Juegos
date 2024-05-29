using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
  public Text textoTiempo; // Texto UI para mostrar el tiempo
  private float tiempoTranscurrido;
  private bool contando;

  void Start()
  {
    tiempoTranscurrido = 0f;
    contando = false;
  }

  void Update()
  {
    if (contando)
    {
      tiempoTranscurrido += Time.deltaTime;
      MostrarTiempo(tiempoTranscurrido);
    }
  }

  public void IniciarTemporizador()
  {
    tiempoTranscurrido = 0f;
    contando = true;
  }

  public void DetenerTemporizador()
  {
    contando = false;
  }

  void MostrarTiempo(float tiempo)
  {
    int minutos = Mathf.FloorToInt(tiempo / 60F);
    int segundos = Mathf.FloorToInt(tiempo % 60F);
    int milisegundos = Mathf.FloorToInt((tiempo * 1000F) % 1000F);
    textoTiempo.text = string.Format("{0:00}:{1:00}:{2:000}", minutos, segundos, milisegundos);
  }

  public float ObtenerTiempo()
  {
    return tiempoTranscurrido;
  }
}
