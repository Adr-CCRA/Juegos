using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UnicoID))]
public class CajaReciclaje : TitularInventario, Interactuable
{
  public int IDTipoCaja; // Identificador de tipo de caja (0 para Plásticos, 1 para Papeles, etc.)
  public string Tipo; // Nombre del tipo (Plásticos, Papeles, etc.)
  public UnityAction<Interactuable> InteraccionCompleta { get; set; }

  // Propiedad pública para acceder a sistemaInventario
  public SistemaInventario SistemaInventarios => sistemaInventario;

  protected override void Awake()
  {
    base.Awake();
    GuardarCargar.CargarJuego += CargarInventario;
  }

  private void Start()
  {
    sistemaInventario.InicializarDatosCaja(IDTipoCaja, Tipo);

    var guardarDatoCaja = new GuardarDatosCaja(sistemaInventario, transform.position, transform.rotation);
    var id = GetComponent<UnicoID>().ID;

    if (!AdministradorGuardarJuego.dato.cajaDiccionario.ContainsKey(id))
    {
      AdministradorGuardarJuego.dato.cajaDiccionario.Add(id, guardarDatoCaja);
    }
    else
    {
      Debug.LogWarning($"La clave {id} ya existe en el diccionario.");
    }
  }

  protected override void CargarInventario(GuardarDato dato)
  {
    if (dato.cajaDiccionario.TryGetValue(GetComponent<UnicoID>().ID, out GuardarDatosCaja datosCaja))
    {
      this.sistemaInventario = datosCaja.invSistema;
      this.transform.position = datosCaja.posicion;
      this.transform.rotation = datosCaja.rotacion;

      this.sistemaInventario.InicializarDatosCaja(IDTipoCaja, Tipo);
    }
  }

  public void Interactuar(Interactor interactor, out bool interactuarExitoso)
  {
    visualizarInventarioDinamicoSolicitado?.Invoke(sistemaInventario, 0);
    interactuarExitoso = true;
  }

  public void FinInteraccion() { }

  // Método para inicializar los datos de la caja
  public void InicializarDatosCaja(int idTipoCaja, string tipo)
  {
    this.IDTipoCaja = idTipoCaja;
    this.Tipo = tipo;
  }
}
