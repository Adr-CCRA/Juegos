using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UnicoID))]

public class CajaReciclaje : TitularInventario, Interactuable
{
  public UnityAction<Interactuable> InteraccionCompleta { get; set; }

  protected override void Awake()
  {
    base.Awake();
    GuardarCargar.CargarJuego += CargarInventario;
  }

  private void Start() {
    var guardarDatoCaja = new GuardarDatosCaja(sistemaInventario, transform.position, transform.rotation);

    AdministradorGuardarJuego.dato.cajaDiccionario.Add(GetComponent<UnicoID>().ID, guardarDatoCaja);
  }

  private void CargarInventario(GuardarDato dato)
  {
    // Verifica los datos guardados para esta caja específica y si existe, cárguelo.
    if(dato.cajaDiccionario.TryGetValue(GetComponent<UnicoID>().ID, out GuardarDatosCaja datosCaja)){
      this.sistemaInventario = datosCaja.invSistema;
      this.transform.position = datosCaja.posicion;
      this.transform.rotation = datosCaja.rotacion;
    }
  }

  public void Interactuar(Interactor interactor, out bool interactuarExitoso)
  {
    visualizarInventarioDinamicoSolicitado?.Invoke(sistemaInventario);
    interactuarExitoso = true;
  }

  public void FinInteraccion()
  {

  }

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
}