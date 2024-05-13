using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class DatosElementosMouse : MonoBehaviour
{
  public Image objetoSprite;
  public TextMeshProUGUI objetoContador;
  public InvetarioRanura AsignarInvetarioRanura;

  private void Awake() {
    objetoSprite.color = Color.clear;
    objetoContador.text = "";
  }
  public void ActualizarRaunuraMouse(InvetarioRanura invRanura){
    AsignarInvetarioRanura.AsignarElemento(invRanura);
    objetoSprite.sprite = invRanura.DatosElemento.icono;
    objetoContador.text = invRanura.CapacidadPila.ToString();
    objetoSprite.color = Color.white;
  }
  private void Update() {
    if(AsignarInvetarioRanura.DatosElemento != null){
      transform.position = Mouse.current.position.ReadValue();
      if(Mouse.current.leftButton.wasPressedThisFrame && !PunteroSobreObjetoUI()){
        LimpiarRanura();
      }
    }
  }
  public void LimpiarRanura(){
    AsignarInvetarioRanura.LimpiarRanura();
    objetoContador.text = "";
    objetoSprite.color = Color.clear;
    objetoSprite.sprite = null;
  }
  public static bool PunteroSobreObjetoUI(){
    PointerEventData datosEventoPosicionActual = new PointerEventData(EventSystem.current);
    datosEventoPosicionActual.position = Mouse.current.position.ReadValue();
    List<RaycastResult> resultados = new List<RaycastResult>();
    EventSystem.current.RaycastAll(datosEventoPosicionActual, resultados);
    return resultados.Count > 0;
  }
}
