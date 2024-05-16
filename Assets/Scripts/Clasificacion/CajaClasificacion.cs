using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class CajaClasificacion : TitularInventario, Clasificable
{
  public int ID;
  public UnityAction<Clasificable> ClasificacionCompleta { get; set; }

  public void Clasificar(Clasificador clasificador, out bool clasificacionExitosa)
  {
    // Actualiza la visualización del inventario dinámico
    visualizarInventarioDinamicoSolicitado?.Invoke(sistemaInventario);
    // Si se clasifican todos los objetos exitosamente, establece clasificacionExitosa en true
    clasificacionExitosa = true;
  }
  public void FinClasificacion()
  {

  }

}
