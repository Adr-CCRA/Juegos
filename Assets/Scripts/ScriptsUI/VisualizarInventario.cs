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
  public void RanuraClicked(RaunuraInventarioUI clickedRanuraUI){
    Debug.Log("ClickedRanura");
    // La ranura en la que se hizo clic tiene un elemento; el mouse no tiene un elemento; recoja ese elemento.
    if(clickedRanuraUI.AsignacionInventarioRanura.DatosElemento != null && elementoInventarioMouse.AsignarInvetarioRanura.DatosElemento == null){
      elementoInventarioMouse.ActualizarRaunuraMouse(clickedRanuraUI.AsignacionInventarioRanura);
      clickedRanuraUI.LimpiarRanura();
      return;
    }
    // La ranura en la que se hizo clic no tiene un elemento: el mouse sí tiene un elemento. Coloque el elemento del mouse en la ranura vacía.
    if(clickedRanuraUI.AsignacionInventarioRanura.DatosElemento == null && elementoInventarioMouse.AsignarInvetarioRanura.DatosElemento != null){
      clickedRanuraUI.AsignacionInventarioRanura.AsignarElemento(elementoInventarioMouse.AsignarInvetarioRanura);
      clickedRanuraUI.ActualizarUIRanura();
      elementoInventarioMouse.LimpiarRanura();
    }
    // Ambos espacios tienen un elemento que decide qué hacer...
    // ¿Ambos elementos son iguales? Si es así combínalos.
    // ¿El tamaño de la pila de la ranura es + el tamaño de la pila del mouse › el tamaño máximo de la pila de la ranura? Si es así, tómelo del mouse. 
    // Si son elementos diferentes, intercámbielos.
  }

}
