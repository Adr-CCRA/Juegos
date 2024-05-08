using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class RecogeElementos : MonoBehaviour
{
  public float obtenerRadio = 1f;
  public DatosInventario datosElemento;
  private SphereCollider sphereCollider;
   private void Awake() {
    sphereCollider = GetComponent<SphereCollider>();
    sphereCollider.isTrigger = true;
    sphereCollider.radius = obtenerRadio;
   }
   private void OnTriggerEnter(Collider other) {
    var inventario = other.transform.GetComponent<TitularInventario>();
    if(!inventario) return;
    if(inventario.SistemaInventario.AgregarInvetario(datosElemento, 1)){
      Destroy(this.gameObject);
    }
   }
}
