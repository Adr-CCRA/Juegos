using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class InvetarioRanura : ISerializationCallbackReceiver
{
  [SerializeField] private int idTipo;
  [SerializeField] private DatosInventario datosElemento;
  [SerializeField] private int _elementoID = -1;
  [SerializeField] private int capacidadPila;

  public int IDTipo => idTipo;
  public DatosInventario DatosElemento => datosElemento;
  public int CapacidadPila => capacidadPila;

  public InvetarioRanura(DatosInventario fuente, int cantidad, int IdTipo)
  {
    this.idTipo = IdTipo;
    datosElemento = fuente;
    _elementoID = datosElemento.ID;
    capacidadPila = cantidad;
  }
  public InvetarioRanura()
  {
    LimpiarRanura();
  }
  public void LimpiarRanura()
  {
    idTipo = -1;
    datosElemento = null;
    _elementoID = -1;
    capacidadPila = -1;
  }
  public void AsignarElemento(InvetarioRanura invRanura)
  {
    if (datosElemento == invRanura.datosElemento)
    {
      AgregarPila(invRanura.capacidadPila);
    }
    else
    {
      idTipo = invRanura.idTipo;
      datosElemento = invRanura.datosElemento;
      _elementoID = datosElemento.ID;
      capacidadPila = 0;
      AgregarPila(invRanura.capacidadPila);
    }
  }
  public void ActualizarInventarioRanura(DatosInventario datos, int cantidad)
  {
    idTipo = datos.IDTipo;
    datosElemento = datos;
    _elementoID = datosElemento.ID;
    capacidadPila = cantidad;
    Debug.Log("ID" + idTipo);
    Debug.Log("elementos: " + datosElemento);
    Debug.Log("capacidad: " + capacidadPila);
  }
  public bool EspacioRestantePila(int agregarCantidad, out int cantidadRestante)
  {
    cantidadRestante = DatosElemento.maxCapacidadPila - capacidadPila;
    return EspacioRestantePila(agregarCantidad);
  }
  public bool EspacioRestantePila(int agregarCantidad)
  {
    if (capacidadPila + agregarCantidad <= datosElemento.maxCapacidadPila)
    {
      return true;
    }
    else { return false; }
  }
  public void AgregarPila(int cantidad)
  {
    capacidadPila += cantidad;
  }
  public void EliminarDePila(int cantidad)
  {
    capacidadPila -= cantidad;
  }

  public bool PilaDividida(out InvetarioRanura pilaDividida)
  {
    if (capacidadPila <= 1)
    {
      pilaDividida = null;
      return false;
    }
    int mediaPila = Mathf.RoundToInt(capacidadPila / 2);
    EliminarDePila(mediaPila);

    pilaDividida = new InvetarioRanura(datosElemento, mediaPila, idTipo);
    return true;
  }

  public void OnBeforeSerialize()
  {
    
  }

  public void OnAfterDeserialize()
  {
    if(_elementoID == -1) return;
    var bd = Resources.Load<BaseDatos>("BaseDeDatos");
    datosElemento = bd.ObtenerElemento(_elementoID);
  }
}
