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

  protected override void CargarInventario(GuardarDato dato)
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
    visualizarInventarioDinamicoSolicitado?.Invoke(sistemaInventario, 0);
    interactuarExitoso = true;
  }

  public void FinInteraccion()
  {

  }

}