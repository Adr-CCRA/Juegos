using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizarInventarioEstatico : VisualizarInventario
{
  [SerializeField] private TitularInventario titularInventario;
  [SerializeField] private RaunuraInventarioUI[] ranuras;
  protected override void Start()
  {
    base.Start();
    if(titularInventario != null){
      sistemaInventario = titularInventario.SistemaInventario;
      sistemaInventario.CambioEnInventarioRanura += ActualizarRanuras;
    } else {
      Debug.LogWarning($"No se asigno inventario en: {this.gameObject}");
    }
    AsignarRanura(sistemaInventario); 
  }
  public override void AsignarRanura(SistemaInventario invVisualizar)
  {
    ranuraDiccionario = new Dictionary<RaunuraInventarioUI, InvetarioRanura>();
    if(ranuras.Length != sistemaInventario.CapacidadInventario){
      Debug.Log($"Las ranuras del inventario no estan sincronizadas con: {this.gameObject}");
    }
    for (int i = 0; i < sistemaInventario.CapacidadInventario; i++)
    {
     ranuraDiccionario.Add(ranuras[i], SistemaInventario.InvetarioRanuras[i]);
     ranuras[i].Inicia(sistemaInventario.InvetarioRanuras[i]); 
    }
  }
}
