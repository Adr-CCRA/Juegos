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
    bool presionarShift = Keyboard.current.leftShiftKey.isPressed;
    // La ranura en la que se hizo clic tiene un elemento; el mouse no tiene un elemento; recoja ese elemento.
    if(clickedRanuraUI.AsignacionInventarioRanura.DatosElemento != null && elementoInventarioMouse.AsignarInvetarioRanura.DatosElemento == null){
      if(presionarShift && clickedRanuraUI.AsignacionInventarioRanura.PilaDividida(out InvetarioRanura mediaPilaRanura)){
        elementoInventarioMouse.ActualizarRaunuraMouse(mediaPilaRanura);
        clickedRanuraUI.ActualizarUIRanura();
        return;
      }else{
        elementoInventarioMouse.ActualizarRaunuraMouse(clickedRanuraUI.AsignacionInventarioRanura);
        clickedRanuraUI.LimpiarRanura();
        return;
      }
    }
    // La ranura en la que se hizo clic no tiene un elemento: el mouse sí tiene un elemento. Coloque el elemento del mouse en la ranura vacía.
    if(clickedRanuraUI.AsignacionInventarioRanura.DatosElemento == null && elementoInventarioMouse.AsignarInvetarioRanura.DatosElemento != null){
      clickedRanuraUI.AsignacionInventarioRanura.AsignarElemento(elementoInventarioMouse.AsignarInvetarioRanura);
      clickedRanuraUI.ActualizarUIRanura();
      elementoInventarioMouse.LimpiarRanura();
      return;
    }
    // Ambos espacios tienen un elemento que decide qué hacer...
    if(clickedRanuraUI.AsignacionInventarioRanura.DatosElemento != null && elementoInventarioMouse.AsignarInvetarioRanura.DatosElemento != null){
      bool esMismoElemento = clickedRanuraUI.AsignacionInventarioRanura.DatosElemento != elementoInventarioMouse.AsignarInvetarioRanura.DatosElemento;
      if(esMismoElemento && clickedRanuraUI.AsignacionInventarioRanura.EspacioRestantePila(elementoInventarioMouse.AsignarInvetarioRanura.CapacidadPila)){
          clickedRanuraUI.AsignacionInventarioRanura.AsignarElemento(elementoInventarioMouse.AsignarInvetarioRanura);
          clickedRanuraUI.ActualizarUIRanura();

          elementoInventarioMouse.LimpiarRanura();
          return;
        } else if(esMismoElemento &&
          !clickedRanuraUI.AsignacionInventarioRanura.EspacioRestantePila(elementoInventarioMouse.AsignarInvetarioRanura.CapacidadPila, out int dejarEnPila)){
            if(dejarEnPila < 1) {IntercambioRanuras(clickedRanuraUI);} // la pila esta llena esto intercambia los elementos
            else {
            int permaneceEnMouse = elementoInventarioMouse.AsignarInvetarioRanura.CapacidadPila - dejarEnPila;
            clickedRanuraUI.AsignacionInventarioRanura.AgregarPila(dejarEnPila);
            clickedRanuraUI.ActualizarUIRanura();

            var nuevoElemento = new InvetarioRanura(elementoInventarioMouse.AsignarInvetarioRanura.DatosElemento, permaneceEnMouse);
            elementoInventarioMouse.LimpiarRanura();
            elementoInventarioMouse.ActualizarRaunuraMouse(nuevoElemento);
            return;
          }
        } else if(clickedRanuraUI.AsignacionInventarioRanura.DatosElemento != elementoInventarioMouse.AsignarInvetarioRanura.DatosElemento){
          IntercambioRanuras(clickedRanuraUI);
          return;
      }
    }
    // ¿Ambos elementos son iguales? Si es así combínalos.
    // ¿El tamaño de la pila de la ranura es + el tamaño de la pila del mouse › el tamaño máximo de la pila de la ranura? Si es así, tómelo del mouse. 
    // Si son elementos diferentes, intercámbielos.
    
  }
  private void IntercambioRanuras(RaunuraInventarioUI clickedRanuraUI){
    var clonarRanura = new InvetarioRanura(elementoInventarioMouse.AsignarInvetarioRanura.DatosElemento, elementoInventarioMouse.AsignarInvetarioRanura.CapacidadPila);
    elementoInventarioMouse.LimpiarRanura();

    elementoInventarioMouse.ActualizarRaunuraMouse(clickedRanuraUI.AsignacionInventarioRanura);
    clickedRanuraUI.LimpiarRanura();
    clickedRanuraUI.AsignacionInventarioRanura.AsignarElemento(clonarRanura);
    clickedRanuraUI.ActualizarUIRanura();
  }

}
