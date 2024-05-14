using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class InvetarioRanura
{
  [SerializeField] private DatosInventario datosElemento;
  [SerializeField] private int capacidadPila;

  public DatosInventario DatosElemento => datosElemento;
  public int CapacidadPila => capacidadPila;

  public InvetarioRanura(DatosInventario fuente, int cantidad){
    datosElemento = fuente;
    capacidadPila = cantidad;
  }
  public InvetarioRanura(){
    LimpiarRanura();
  }
  public void LimpiarRanura(){
    datosElemento = null;
    capacidadPila = -1;
  }
  public void AsignarElemento(InvetarioRanura invRanura){
    if(datosElemento == invRanura.datosElemento){
      AgregarPila(invRanura.capacidadPila);
    } else {
      datosElemento = invRanura.datosElemento;
      capacidadPila = 0;
      AgregarPila(invRanura.capacidadPila);
    }
  }
  public void ActualizarInventarioRanura(DatosInventario datos, int cantidad){
    datosElemento = datos;
    capacidadPila = cantidad;
    Debug.Log("elementos: " + datosElemento);
    Debug.Log("capacidad: " + capacidadPila);
  }
  public bool EspacioRestantePila(int agregarCantidad, out int cantidadRestante){
    cantidadRestante = DatosElemento.maxCapacidadPila - capacidadPila;
    return EspacioRestantePila(agregarCantidad);
  }
  public bool EspacioRestantePila(int agregarCantidad){
    if(capacidadPila + agregarCantidad <= datosElemento.maxCapacidadPila){
      return true;
    } else { return false; }
  }
  public void AgregarPila(int cantidad){
    capacidadPila += cantidad;
  }
  public void EliminarDePila(int cantidad){
    capacidadPila -= cantidad;
  }

  public bool PilaDividida(out InvetarioRanura pilaDividida){
    if(capacidadPila <= 1){
      pilaDividida = null;
      return false;
    }
    int mediaPila = Mathf.RoundToInt(capacidadPila / 2);
    EliminarDePila(mediaPila);

    pilaDividida = new InvetarioRanura(datosElemento, mediaPila);
    return true;
  }
}
