using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class CajaReciclaje : TitularInventario, Interactuable
{
  public UnityAction<Interactuable> InteraccionCompleta { get; set; }
  
  void Interactuable.Interactuar(Interactor interactor, out bool interactuarExitoso)
  {
    visualizarInventarioDinamicoSolicitado?.Invoke(sistemaInventario);
    interactuarExitoso = true;
  }

  void Interactuable.FinInteraccion()
  {
    
  }

}
