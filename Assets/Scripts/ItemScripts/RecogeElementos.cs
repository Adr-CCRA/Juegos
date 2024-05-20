using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Scripting;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(UnicoID))]
public class RecogeElementos : MonoBehaviour
{
  public float obtenerRadio = 1f;
  public DatosInventario datosElemento;
  private SphereCollider sphereCollider;

  [SerializeField] private GuardarDatosElementoRecogidos guardarDatosElemento;
  private string id;
   private void Awake() {
    id = GetComponent<UnicoID>().ID;
    GuardarCargar.CargarJuego += CargarJuego;
    guardarDatosElemento = new GuardarDatosElementoRecogidos(datosElemento, transform.position, transform.rotation);

    sphereCollider = GetComponent<SphereCollider>();
    sphereCollider.isTrigger = true;
    sphereCollider.radius = obtenerRadio;
   }

   private void Start() {
    AdministradorGuardarJuego.dato.activarElementos.Add(id, guardarDatosElemento);
   }

    private void CargarJuego(GuardarDato dato)
    {
        if(dato.colectarElementos.Contains(id)) Destroy(this.gameObject);
    }

    private void OnDestroy() {
      if(AdministradorGuardarJuego.dato.activarElementos.ContainsKey(id)) AdministradorGuardarJuego.dato.activarElementos.Remove(id);
      GuardarCargar.CargarJuego -= CargarJuego;
    }

    private void OnTriggerEnter(Collider other) {
    var inventario = other.transform.GetComponent<PersonajeTitularInventario>();
    if(!inventario) return;
    if(inventario.AgregarInventario(datosElemento, 1)){
      AdministradorGuardarJuego.dato.colectarElementos.Add(id);
      Destroy(this.gameObject);
    }
   }
}

[System.Serializable]
public struct GuardarDatosElementoRecogidos
{
  public DatosInventario DatosElemento;
  public Vector3 Posicion;
  public Quaternion Rotacion;

  public GuardarDatosElementoRecogidos(DatosInventario _dato, Vector3 _posicion, Quaternion _rotacion){
    DatosElemento = _dato;
    Posicion = _posicion;
    Rotacion = _rotacion;
  }
}