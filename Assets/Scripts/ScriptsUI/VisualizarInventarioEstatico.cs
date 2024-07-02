using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizarInventarioEstatico : VisualizarInventario
{
  [SerializeField] private TitularInventario titularInventario;
  [SerializeField] private RaunuraInventarioUI[] ranuras;

  private void OnEnable()
  {
    PersonajeTitularInventario.cambioInventarioPersonaje += ActualizarVisualizarEstatico;
  }

  private void OnDisable() {
    PersonajeTitularInventario.cambioInventarioPersonaje -= ActualizarVisualizarEstatico;
  }

  private void ActualizarVisualizarEstatico()
  {
    if (titularInventario != null)
    {
      sistemaInventario = titularInventario.SistemaInventario;
      sistemaInventario.CambioEnInventarioRanura += ActualizarRanuras;
    }
    else
    {
      Debug.LogWarning($"No se asigno inventario en: {this.gameObject}");
    }
    AsignarRanura(sistemaInventario, 0);
  }

  protected override void Start()
  {
    base.Start();
    ActualizarVisualizarEstatico();
  }
  private void Update() {
    ActualizarVisualizarEstatico();
  }
  public override void AsignarRanura(SistemaInventario invVisualizar, int compensar)
  {
    ranuraDiccionario = new Dictionary<RaunuraInventarioUI, InvetarioRanura>();
    /* if(ranuras.Length != sistemaInventario.CapacidadInventario){
      Debug.Log($"Las ranuras del inventario no estan sincronizadas con: {this.gameObject}");
    } */
    for (int i = 0; i < titularInventario.Compensar; i++)
    {
      ranuraDiccionario.Add(ranuras[i], SistemaInventario.InvetarioRanuras[i]);
      ranuras[i].Inicia(sistemaInventario.InvetarioRanuras[i]);
    }
  }
}
