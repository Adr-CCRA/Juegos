using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class InvetarioRanura
{
  [SerializeField] private int id;
  [SerializeField] private DatosInventario datosElemento;
  [SerializeField] private int capacidadPila;

  public int ID => id;
  public DatosInventario DatosElemento => datosElemento;
  public int CapacidadPila => capacidadPila;

  public InvetarioRanura(DatosInventario fuente, int cantidad, int Id){
    this.id = Id;
    datosElemento = fuente;
    capacidadPila = cantidad;
  }
  public InvetarioRanura(){
    LimpiarRanura();
  }
  public void LimpiarRanura(){
    id = -1;
    datosElemento = null;
    capacidadPila = -1;
  }
  public void AsignarElemento(InvetarioRanura invRanura){
    if(datosElemento == invRanura.datosElemento){
      AgregarPila(invRanura.capacidadPila);
    } else {
      id = invRanura.id;
      datosElemento = invRanura.datosElemento;
      capacidadPila = 0;
      AgregarPila(invRanura.capacidadPila);
    }
  }
  public void ActualizarInventarioRanura(DatosInventario datos, int cantidad){
    id = datos.ID;
    datosElemento = datos;
    capacidadPila = cantidad;
    Debug.Log("ID" + id);
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

    pilaDividida = new InvetarioRanura(datosElemento, mediaPila, id);
    return true;
  }
}
