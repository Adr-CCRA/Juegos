using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
[ExecuteInEditMode]
public class UnicoID : MonoBehaviour
{
  [ReadOnly, SerializeField] private string _id = Guid.NewGuid().ToString();
  [SerializeField] private string _tipo;
  [SerializeField]
  private static SerializableDiccionario<string, GameObject> idBaseDatos =
    new SerializableDiccionario<string, GameObject>();

  public string ID => _id;
  public string Tipo => _tipo;

  private void OnValidate() {
    if (idBaseDatos.ContainsKey(_id))
    {
        Debug.LogWarning($"ID duplicado encontrado: {_id}. Generando un nuevo ID.");
        Generar();
    }
    else
    {
        idBaseDatos.Add(_id, this.gameObject);
    }
  }

  private void OnDestroy() {
    if(idBaseDatos.ContainsKey(_id)) idBaseDatos.Remove(_id);
  }

  private void Generar(){
    _id = Guid.NewGuid().ToString();
    if (!idBaseDatos.ContainsKey(_id))
    {
        idBaseDatos.Add(_id, this.gameObject);
    }
    else
    {
        Debug.LogError($"El nuevo ID {_id} también ya existe. Esto no debería suceder.");
    }
  }
}
