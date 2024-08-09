using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PersonajeController : MonoBehaviour
{
  private ActionAssets accionPersonaje;
  private InputAction Mover;
  CamaraController camaraController;
  EntradaController entradaController;
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
  private Animator animador;

  private void Awake()
  {
    rb = this.GetComponent<Rigidbody>();
    accionPersonaje = new ActionAssets();
    animador = this.GetComponent<Animator>();
    camaraController = FindObjectOfType<CamaraController>();
  }

  private void OnEnable()
  {
    accionPersonaje.Personaje.Agarrar.started += agarrarObjeto;
    Mover = accionPersonaje.Personaje.Mover;
    accionPersonaje.Personaje.Enable();
  }

  private void OnDisable()
  {
    accionPersonaje.Personaje.Agarrar.started -= agarrarObjeto;
    accionPersonaje.Personaje.Disable();
  }

  private void FixedUpdate()
  {
    Vector2 movimientoInput = Mover.ReadValue<Vector2>();

    Vector3 fuerzaMovimientoX = movimientoInput.x * obtenerCamaraDer(personajeCamara) * fuerzaMovimiento;
    fuerzaDireccion += fuerzaMovimientoX;

    Vector3 fuerzaMovimientoY = movimientoInput.y * obtenerCamaraAdelante(personajeCamara) * fuerzaMovimiento;
    fuerzaDireccion += fuerzaMovimientoY;

    rb.AddForce(fuerzaDireccion, ForceMode.Impulse);
    fuerzaDireccion = Vector3.zero;

    if (rb.velocity.y < 0f)
    {
      rb.velocity += Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
    }
    Vector3 velocidadHorizontal = rb.velocity;
    velocidadHorizontal.y = 0;
    if (velocidadHorizontal.sqrMagnitude > velocidadMaxima * velocidadMaxima)
    {
      rb.velocity = velocidadHorizontal.normalized * velocidadMaxima + Vector3.up * rb.velocity.y;
    }
    mirar();
  }

  private void LateUpdate()
  {
    camaraController.TodoMovimientoCamara();
  }

  private void mirar()
  {
    Vector3 direccion = rb.velocity;
    Vector3 movimientoInput = Mover.ReadValue<Vector2>();
    direccion.y = 0f;
    if (movimientoInput.sqrMagnitude > 0.1f && direccion.sqrMagnitude > 0.1f)
    {
      this.rb.rotation = Quaternion.LookRotation(direccion, Vector3.up);
    }
  }

  private Vector3 obtenerCamaraAdelante(Camera personajeCamara)
  {
    Vector3 delantera = personajeCamara.transform.forward;
    delantera.y = 0;
    return delantera.normalized;
  }

  private Vector3 obtenerCamaraDer(Camera personajeCamara)
  {
    Vector3 derecha = personajeCamara.transform.right;
    derecha.y = 0;
    return derecha.normalized;
  }

  private void agarrarObjeto(InputAction.CallbackContext context)
  {
    animador.SetTrigger("Agarrar");
  }
}
