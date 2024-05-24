using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System.Data.Common;

[System.Serializable]
public class SistemaInventario
{
  [SerializeField] private List<InvetarioRanura> invetarioRanuras;

  public List<InvetarioRanura> InvetarioRanuras => invetarioRanuras;
  public int CapacidadInventario => InvetarioRanuras.Count;
  public UnityAction<InvetarioRanura> CambioEnInventarioRanura;

  public int datosCaja;
  public int IDTipoCaja { get; private set; }
  public string Tipo { get; private set; }

  public SistemaInventario(int capacidad)
  {
    invetarioRanuras = new List<InvetarioRanura>(capacidad);
    for (int i = 0; i < capacidad; i++)
    {
      invetarioRanuras.Add(new InvetarioRanura());
    }
  }

  public bool AgregarInvetario(DatosInventario agregarElemento, int agregarCantidad)
  {
    if (ContenedorElemento(agregarElemento, out List<InvetarioRanura> invRanura))
    { //verifica si existe elementos en el inventario
      foreach (var ranura in invRanura)
      {
        if (ranura.EspacioRestantePila(agregarCantidad))
        {
          ranura.AgregarPila(agregarCantidad);
          CambioEnInventarioRanura?.Invoke(ranura);
        }
      }
      return true;
    }
    if (EspacioLibreRanura(out InvetarioRanura libreRanura))
    { // obtiene el primer espacio libre
      libreRanura.ActualizarInventarioRanura(agregarElemento, agregarCantidad);
      return true;
    }
    return false;
  }

  public bool ContenedorElemento(DatosInventario agregarElemento, out List<InvetarioRanura> invRanura)
  {
    invRanura = InvetarioRanuras.Where(i => i.DatosElemento == agregarElemento).ToList();
    Debug.Log("invRanura:  " + invRanura.Count);
    return invRanura.Any();
  }

  public bool EspacioLibreRanura(out InvetarioRanura libreRanura)
  {
    libreRanura = InvetarioRanuras.Where(i => i.DatosElemento == null).FirstOrDefault();
    return libreRanura != null;
  }

  public void InicializarDatosCaja(int idTipoCaja, string tipo)
  {
    this.IDTipoCaja = idTipoCaja;
    this.Tipo = tipo;
  }
}
