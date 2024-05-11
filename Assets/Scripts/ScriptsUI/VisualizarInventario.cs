using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class VisualizarInventario : MonoBehaviour
{
  [SerializeField] DatosElementosMouse elementoInventarioMouse;
  protected SistemaInventario sistemaInventario;
  protected Dictionary<RaunuraInventarioUI, InvetarioRanura> ranuraDiccionario;

  public SistemaInventario SistemaInventario => sistemaInventario;
  public Dictionary<RaunuraInventarioUI, InvetarioRanura> RanuraDiccionario => ranuraDiccionario;
  protected virtual void Start() {
    
  }
  public abstract void AsignarRanura(SistemaInventario invVisualizar);
  protected virtual void ActualizarRanuras(InvetarioRanura actualizarRanura){
    foreach (var ranura in RanuraDiccionario)
    {
      if(ranura.Value == actualizarRanura){
        ranura.Key.ActualizarUIRanura(actualizarRanura);
      }      
    }
  }
  public void RanuraClicked(RaunuraInventarioUI clickedRanura){
    Debug.Log("ClickedRanura");
  }

}
