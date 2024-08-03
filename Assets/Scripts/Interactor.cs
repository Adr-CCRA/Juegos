using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
  public Transform PuntoInteraccion;
  public LayerMask CapaInteraccion;
  public float PuntoRadioInteraccion = 1f;
  public bool Interactuando { get; set; }
  public System.Action<bool> CajaAbiertaCallback; // Delegate to notify box state change

  private void Update()
  {
    var colisiones = Physics.OverlapSphere(PuntoInteraccion.position, PuntoRadioInteraccion, CapaInteraccion);

    if (Keyboard.current.fKey.wasPressedThisFrame)
    {
      for (int i = 0; i < colisiones.Length; i++)
      {
        var interactuable = colisiones[i].GetComponent<Interactuable>();
        if (interactuable != null) IniciarInteraccion(interactuable);
      }
    }
  }

  public void InteractuarConCaja()
  {
    var colisiones = Physics.OverlapSphere(PuntoInteraccion.position, PuntoRadioInteraccion, CapaInteraccion);

    for (int i = 0; i < colisiones.Length; i++)
    {
      var caja = colisiones[i].GetComponent<CajaReciclaje>();
      if (caja != null)
      {
        caja.Interactuar(this, out bool interactuarExitoso);
        CajaAbiertaCallback?.Invoke(interactuarExitoso);
      }
    }
  }

  void IniciarInteraccion(Interactuable interactuable)
  {
    interactuable.Interactuar(this, out bool interactuarExitoso);
    Interactuando = true;
  }

  void FinInteraccion()
  {
    Interactuando = false;
  }
}
