using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
  public Transform PuntoInteraccion;
  public LayerMask CapaInteraccion;
  public float PuntoRadioInteraccion = 1f;
  public bool Interactuando { get; set; }
  private void Update() {
    var colisiones = Physics.OverlapSphere(PuntoInteraccion.position, PuntoRadioInteraccion, CapaInteraccion);

    if(Keyboard.current.fKey.wasPressedThisFrame){
      for (int i = 0; i < colisiones.Length; i++)
      {
        var interactuable = colisiones[i].GetComponent<Interactuable>();
        if(interactuable != null) IniciarInteraccion(interactuable);
      }
    }
  }

  void IniciarInteraccion(Interactuable interactuable){
    interactuable.Interactuar(this, out bool interactuarExitoso);
    Interactuando = true;
  }

  void FinInteraccion(){
    Interactuando = false;
  }
}
