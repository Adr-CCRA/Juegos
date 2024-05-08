using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class SistemaInventario
{
   [SerializeField] private List<InvetarioRanura> invetarioRanuras;
   
   public List<InvetarioRanura> InvetarioRanuras => invetarioRanuras;
   public int CapacidadInventario => InvetarioRanuras.Count;  
   public UnityAction<InvetarioRanura> CambioEnInventarioRanura;

   public SistemaInventario(int capacidad){
    invetarioRanuras = new List<InvetarioRanura>(capacidad);
    for(int i = 0 ; i < capacidad ; i++){
      invetarioRanuras.Add(new InvetarioRanura());
    }
   }

   public bool AgregarInvetario(DatosInventario agregarElemento, int agregarCantidad){
    invetarioRanuras[0] = new InvetarioRanura(agregarElemento, agregarCantidad);
    return true;
   }
}
