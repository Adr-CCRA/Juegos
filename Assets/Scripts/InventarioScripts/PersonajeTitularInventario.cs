using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PersonajeTitularInventario : TitularInventario
{
  [SerializeField] protected int capacidadInventarioSecundario;
  [SerializeField] protected SistemaInventario sistemaInventarioSecundario;

  public SistemaInventario SistemaInventarioSecundario => sistemaInventarioSecundario;
  public static UnityAction<SistemaInventario> visualizarMochilaPersonajeDinamicoSolicitado;
  protected override void Awake() {
    base.Awake();

    sistemaInventarioSecundario = new SistemaInventario(capacidadInventarioSecundario);
  }
  private void Update() {
    if(Keyboard.current.bKey.wasPressedThisFrame){
      visualizarMochilaPersonajeDinamicoSolicitado?.Invoke(sistemaInventarioSecundario);
    }
  }

  public bool AgregarInventario(DatosInventario fuente, int cantidad){
    if(sistemaInventario.AgregarInvetario(fuente, cantidad)){
      return true;
    } else if (sistemaInventarioSecundario.AgregarInvetario(fuente, cantidad)) {
      return true;
    }
    return false;
  }
}
