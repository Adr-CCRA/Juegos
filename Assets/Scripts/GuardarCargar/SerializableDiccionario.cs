using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
 public class SerializableDiccionario<TClave, TValor> : Dictionary<TClave, TValor>, ISerializationCallbackReceiver
 {
     [SerializeField]
     private List<TClave> claves = new List<TClave>();
     
     [SerializeField]
     private List<TValor> valores = new List<TValor>();
     
    // guardar el diccionario en listas
     public void OnBeforeSerialize()
     {
         claves.Clear();
         valores.Clear();
         foreach(KeyValuePair<TClave, TValor> pair in this)
         {
             claves.Add(pair.Key);
             valores.Add(pair.Value);
         }
     }
     
     // cargar diccionario de listas
     public void OnAfterDeserialize()
     {
         this.Clear();
 
         if(claves.Count != valores.Count)
             throw new System.Exception(string.Format("hay {0} claves y {1} valores después de la deserialización. Asegúrese de que tanto los tipos de clave como de valor sean serializables."));
 
         for(int i = 0; i < claves.Count; i++)
             this.Add(claves[i], valores[i]);
     }
 }
