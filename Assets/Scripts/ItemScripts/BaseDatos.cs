using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using DPUtils.Systems.ItemSystem.Scriptable_Objects;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace DPUtils.Systems.ItemSystem.Scriptable_Objects.Items.Resources
{
  [CreateAssetMenu(menuName = "Base de datos de objetos")]
  public class BaseDatos : ScriptableObject
  {
    [SerializeField] private List<DatosInventario> _elementosBD;

    public List<DatosInventario> ElementoBD => _elementosBD;
    [ContextMenu("Establecer ID's")]
    public void EstablecerElementoIDs()
    {
      _elementosBD = new List<DatosInventario>();

      var encontrarELementos = UnityEngine.Resources.LoadAll<DatosInventario>("DatoElemento").OrderBy(i => i.ID).ToList();
      var tieneIDDentroRango = encontrarELementos.Where(i => i.ID != -1 && i.ID < encontrarELementos.Count).OrderBy(i => i.ID).ToList();
      var noTieneIDDentroRango = encontrarELementos.Where(i => i.ID != -1 && i.ID >= encontrarELementos.Count).OrderBy(i => i.ID).ToList(); ;
      var noID = encontrarELementos.Where(i => i.ID <= -1).ToList();

      var index = 0;
      for (int i = 0; i < encontrarELementos.Count; i++)
      {
        // DatosInventario agregarElementos;
        var agregarElementos = encontrarELementos.Find(j => j.ID == i);

        if (agregarElementos != null)
        {
          _elementosBD.Add(agregarElementos);
        }
        else if (index < noID.Count)
        {
          noID[index].ID = i;
          agregarElementos = noID[index];
          index++;
          _elementosBD.Add(agregarElementos);
        }
#if UNITY_EDITOR
      if (agregarElementos) EditorUtility.SetDirty(agregarElementos);
#endif 
      }     
      foreach (var elemento in noTieneIDDentroRango)
      {
        _elementosBD.Add(elemento);
#if UNITY_EDITOR
        if (elemento) EditorUtility.SetDirty(elemento);
#endif
      }
#if UNITY_EDITOR
      AssetDatabase.SaveAssets();
#endif
    }

    public DatosInventario ObtenerElemento(int id)
    {
      return _elementosBD.Find(i => i.ID == id);
    }

    public DatosInventario ObtenerElemento(string mostrarNombre)
        {
            return _elementosBD.Find(i => i.mostrarNombre == mostrarNombre);
        }
  }
}
