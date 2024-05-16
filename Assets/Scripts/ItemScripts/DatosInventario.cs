using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Nombre/Tipo : Basura")]
public class DatosInventario : ScriptableObject
{
  public int ID;
  public string mostrarNombre;
  [TextArea(4, 4)]
  public string Descripcion;
  public Sprite icono;
  public int maxCapacidadPila;
}
