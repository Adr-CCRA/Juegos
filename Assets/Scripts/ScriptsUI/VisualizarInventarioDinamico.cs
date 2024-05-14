using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class VisualizarInventarioDinamico : VisualizarInventario
{
  [SerializeField] protected RaunuraInventarioUI ranuraPrefab;
  protected override void Start() {
    base.Start();
  }
  public void ActualizarInventarioDinamico(SistemaInventario invVisualizar){
    LimpiarRanuras();
    sistemaInventario = invVisualizar;
    AsignarRanura(invVisualizar);
  }

  public override void AsignarRanura(SistemaInventario invVisualizar)
  {
      LimpiarRanuras();

      ranuraDiccionario = new Dictionary<RaunuraInventarioUI, InvetarioRanura>();

      if(invVisualizar == null) return;

      for (int i = 0; i < invVisualizar.CapacidadInventario; i++)
      {
        var uiRanura = Instantiate(ranuraPrefab, transform);
        ranuraDiccionario.Add(uiRanura, invVisualizar.InvetarioRanuras[i]);
        uiRanura.Inicia(invVisualizar.InvetarioRanuras[i]);
        uiRanura.ActualizarUIRanura();
      }
  }

  private void LimpiarRanuras(){
    foreach (var elemento in transform.Cast<Transform>())
    {
      Destroy(elemento.gameObject);
    }

    if (ranuraDiccionario != null) ranuraDiccionario.Clear();
    
  }
}
