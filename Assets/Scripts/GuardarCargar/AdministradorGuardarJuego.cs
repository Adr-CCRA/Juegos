using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorGuardarJuego : MonoBehaviour
{
  public static GuardarDato dato;

  private void Awake()
  {
    dato = new GuardarDato();
    GuardarCargar.CargarJuego += CargarDato;
  }

  public void EliminarDato(){
    GuardarCargar.EliminarDatoGuardado();
  }

  public static void GuardarDato(){
    var guardarDato = dato;
    GuardarCargar.Guardar(guardarDato);
  }

  public static void CargarDato(GuardarDato _dato)
  {
    dato = _dato;
  }

  public static void ICargarDato(){
    GuardarCargar.Cargar();
  }
}
