using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

public class PersonajeController : MonoBehaviour
{
  private ActionAssets accionPersonaje;
  private InputAction Mover;

  private Rigidbody rb;
  [SerializeField]
  private float fuerzaMovimiento = 1f;
  [SerializeField]
  private float fuerzaCorrer = 2f;
  [SerializeField]
  private float velocidadMaxima = 5f;
  private Vector3 fuerzaDireccion = Vector3.zero;
  [SerializeField]
  private Camera personajeCamara;
  private void Awake() {
    rb = this.GetComponent<Rigidbody>();
    accionPersonaje = new ActionAssets();
  }

  private void OnEnable() {
    Mover = accionPersonaje.Personaje.Mover;
    accionPersonaje.Personaje.Enable();
  }
  private void OnDisable() {
    accionPersonaje.Personaje.Disable();
  }
  private void FixedUpdate() {
    Vector2 movimientoInput = Mover.ReadValue<Vector2>();
    
    // Calcula la fuerza de movimiento en el eje X y suma a la dirección total
    Vector3 fuerzaMovimientoX = movimientoInput.x * obtenerCamaraDer(personajeCamara) * fuerzaMovimiento;
    fuerzaDireccion += fuerzaMovimientoX;
    
    // Calcula la fuerza de movimiento en el eje Y y suma a la dirección total
    Vector3 fuerzaMovimientoY = movimientoInput.y * obtenerCamaraAdelante(personajeCamara) * fuerzaMovimiento;
    fuerzaDireccion += fuerzaMovimientoY;
    
    Debug.Log(fuerzaDireccion);
    rb.AddForce(fuerzaDireccion, ForceMode.Impulse);
    
    // Reinicia la dirección total de la fuerza
    fuerzaDireccion = Vector3.zero;

    if(rb.velocity.y < 0f){
        rb.velocity += Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
    }
    Vector3 velocidadHorizontal = rb.velocity;
    velocidadHorizontal.y = 0;
    if(velocidadHorizontal.sqrMagnitude > velocidadMaxima * velocidadMaxima){
        rb.velocity = velocidadHorizontal.normalized * velocidadMaxima + Vector3.up * rb.velocity.y;
    }
    mirar();
  }
  private void mirar(){
    Vector3 direccion = rb.velocity;
    Vector3 movimientoInput = Mover.ReadValue<Vector2>();
    direccion.y = 0f;
    if(movimientoInput.sqrMagnitude > 0.1f && direccion.sqrMagnitude > 0.1f){
      this.rb.rotation = Quaternion.LookRotation(direccion, Vector3.up);
    }

  }

  private Vector3 obtenerCamaraAdelante(Camera personajeCamara) {
    Vector3 delantera = personajeCamara.transform.forward;
    delantera.y = 0;
    return delantera.normalized;
  }
  private Vector3 obtenerCamaraDer(Camera personajeCamara) {
    Vector3 derecha = personajeCamara.transform.right;
    derecha.y = 0;
    return derecha.normalized;
  } 
  private bool esSuelo() {
    Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
    if (Physics.Raycast(ray, out RaycastHit hit, 0.3f)){
        return true;
    } else {
        return false;
    }
  }
}
