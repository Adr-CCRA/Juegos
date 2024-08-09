using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
  EntradaController entradaController;
  PersonajeController personajeController;
  public Transform transformarObjeto;
  public Transform camaraPivot;
  public Transform transformarCamara;
  public LayerMask capasColision;
  private Vector3 velocidadSegumientoCamara = Vector3.zero;
  private float posicionDefecto;
  private Vector3 camaraPosicionVector;

  public float camaraColisionDesactivar = 0.2f;
  public float minCamaraColisionDesactivar = 0.2f;
  public float radioColisionCamara = 2;
  public float velocidadCamara = 0.2f;
  public float velocidadMirarCamara = 1;
  public float velocidadPivotCamara = 1;

  public float mirarAngulo;
  public float pivotAngulo;
  public float minPivotAngulo = -35;
  public float maxPivotAngulo = 35;

  private void Awake()
  {
    entradaController = FindObjectOfType<EntradaController>();
    transformarObjeto = FindObjectOfType<PersonajeController>().transform;
    transformarCamara = Camera.main.transform;
    posicionDefecto = transformarCamara.localPosition.z;
  }

  public void TodoMovimientoCamara()
  {
    SeguirObjeto();
    RotacionCamara();
  }

  private void LateUpdate()
  {
    TodoMovimientoCamara();
    ManejoColisionCamara();
  }

  private void SeguirObjeto()
  {
    Vector3 posicionObjeto = Vector3.SmoothDamp(
        transform.position, transformarObjeto.position, ref velocidadSegumientoCamara, velocidadCamara);
    transform.position = posicionObjeto;
  }

  private void RotacionCamara()
  {
    Vector3 rotacion;
    Quaternion objetoRotacion;
    mirarAngulo += entradaController.entradaCamaraX * velocidadMirarCamara;
    pivotAngulo += entradaController.entradaCamaraY * velocidadPivotCamara;
    pivotAngulo = Mathf.Clamp(pivotAngulo, minPivotAngulo, maxPivotAngulo);

    rotacion = Vector3.zero;
    rotacion.y = mirarAngulo;
    objetoRotacion = Quaternion.Euler(rotacion);
    transform.rotation = objetoRotacion;

    rotacion = Vector3.zero;
    rotacion.x = pivotAngulo;
    objetoRotacion = Quaternion.Euler(rotacion);
    camaraPivot.localRotation = objetoRotacion;
  }

  private void ManejoColisionCamara()
  {
    float posicionObjeto = posicionDefecto;
    RaycastHit golpe;
    Vector3 direccion = transformarCamara.position - camaraPivot.position;
    direccion.Normalize();

    // Usando Physics.Raycast para la detección de colisiones
    if (Physics.Raycast(
            camaraPivot.position, direccion, out golpe, Mathf.Abs(posicionObjeto), capasColision))
    {
      float distancia = Vector3.Distance(camaraPivot.position, golpe.point);
      posicionObjeto = -distancia + camaraColisionDesactivar;
    }

    if (Mathf.Abs(posicionObjeto) < minCamaraColisionDesactivar)
    {
      posicionObjeto = -minCamaraColisionDesactivar;
    }

    camaraPosicionVector.z = Mathf.Lerp(transformarCamara.localPosition.z, posicionObjeto, 0.2f);
    transformarCamara.localPosition = camaraPosicionVector;

    // Debug para visualizar el raycast
    /* Debug.DrawRay(camaraPivot.position, direccion * Mathf.Abs(posicionObjeto), Color.red);
    Debug.Log("Posición de la cámara: " + transformarCamara.localPosition);
    Debug.Log("Distancia de colisión calculada: " + posicionObjeto); */
  }
}
