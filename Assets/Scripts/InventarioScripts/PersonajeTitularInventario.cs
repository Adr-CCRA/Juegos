using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PersonajeTitularInventario : TitularInventario
{
  public static UnityAction cambioInventarioPersonaje;
  public static UnityAction<SistemaInventario, int> visualizarInventarioPersonajeSolicitado;

  private void Start() {
    AdministradorGuardarJuego.dato.inventarioPersonje = new GuardarDatosCaja(sistemaInventario);
  }

  protected override void CargarInventario(GuardarDato dato)
  {
    // Verifica los datos guardados para esta caja específica y si existe, cárguelo.
    if(dato.inventarioPersonje.invSistema != null){
      this.sistemaInventario = dato.inventarioPersonje.invSistema;
      cambioInventarioPersonaje?.Invoke();
    }
  }

  private void Update() {
    if(Keyboard.current.bKey.wasPressedThisFrame){
      visualizarInventarioPersonajeSolicitado?.Invoke(sistemaInventario, compensar);
    }
  }

  public bool AgregarInventario(DatosInventario fuente, int cantidad){
    if(sistemaInventario.AgregarInvetario(fuente, cantidad)){
      return true;
    }
    return false;
  }
}
