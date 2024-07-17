using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class TitularInventario : MonoBehaviour
{
  [SerializeField] protected int compensar;
  [SerializeField] private int capacidadInventario;
  [SerializeField] protected SistemaInventario sistemaInventario;

  public int Compensar => compensar;

  public SistemaInventario SistemaInventario => sistemaInventario;

  public static UnityAction<SistemaInventario, int> visualizarInventarioDinamicoSolicitado;

  protected virtual void Awake()
  {
    GuardarCargar.CargarJuego += CargarInventario;

    sistemaInventario = new SistemaInventario(capacidadInventario);
  }

  protected abstract void CargarInventario(GuardarDato guardarDato);
}

[System.Serializable]
public struct GuardarDatosCaja
{
  public SistemaInventario invSistema;
  public Vector3 posicion;
  public Quaternion rotacion;

  public GuardarDatosCaja(SistemaInventario _invSistema, Vector3 _posicion, Quaternion _rotacion)
  {
    // Datos Guardados en el cofre
    invSistema = _invSistema;
    posicion = _posicion;
    rotacion = _rotacion;
  }

  public GuardarDatosCaja(SistemaInventario _invSistema)
  {
    invSistema = _invSistema;
    posicion = Vector3.zero;
    rotacion = Quaternion.identity;
  }
}
