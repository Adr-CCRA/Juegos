using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Base de datos de objetos")]
public class BaseDatos : ScriptableObject
{
  [SerializeField] private List<DatosInventario> _elementosBD;
  [ContextMenu("Establecer ID's")]
  public void EstablecerElementoIDs(){
    _elementosBD = new List<DatosInventario>();
    
    var encontrarELementos = Resources.LoadAll<DatosInventario>("DatoElemento").OrderBy(i => i.ID).ToList();
    var tieneIDDentroRango = encontrarELementos.Where(i => i.ID != -1 && i.ID < encontrarELementos.Count).OrderBy(i => i.ID).ToList();
    var noTieneIDDentroRango = encontrarELementos.Where(i => i.ID != -1 && i.ID >= encontrarELementos.Count).OrderBy(i => i.ID).ToList();;
    var noID = encontrarELementos.Where(i => i.ID <= -1).ToList();

    var index = 0;
    for (int i = 0; i < encontrarELementos.Count; i++)
    {
      DatosInventario agregarElementos;
      agregarElementos = encontrarELementos.Find(j => j.ID == i);

      if(agregarElementos != null){
        _elementosBD.Add(agregarElementos);
      } else if(index < noID.Count){
        noID[index].ID = i;
        agregarElementos = noID[index];
        index++;
        _elementosBD.Add(agregarElementos);
      }
    }
    foreach (var elemento in noTieneIDDentroRango)
    {
      _elementosBD.Add(elemento);
    }
  }

  public DatosInventario ObtenerElemento(int id){
    return _elementosBD.Find(i => i.ID == id);
  }
}
