using UnityEngine;
using UnityEngine.Events;

public class PuertaController : MonoBehaviour
{
  public bool puertaAbierta = false;
  public UnityEvent<bool> OnPuertaEstadoCambiado = new UnityEvent<bool>();
  public float anguloApertura = -95f;
  public float velocidadRotacionPuerta = 3.0f;

  private float yInicial;
  private float xInicial;
  private float zInicial;

  public AudioClip abrirPuerta;
  public AudioClip cerrarPuerta;

  public bool puedeInteractuar = false; // Nueva variable para habilitar/deshabilitar la interacción

  public void CambioEstadoPuerta()
  {
    if (!puedeInteractuar) return; // Si no se puede interactuar, no hacer nada
    puertaAbierta = !puertaAbierta;
    OnPuertaEstadoCambiado?.Invoke(puertaAbierta);
  }

  void Start()
  {
    // Guardamos las rotaciones iniciales en los ejes X, Y y Z
    yInicial = transform.localEulerAngles.y;
    xInicial = transform.localEulerAngles.x;
    zInicial = transform.localEulerAngles.z;
  }

  void Update()
  {
    // Calculamos el ángulo destino en el eje Y en función del estado de la puerta (abierta o cerrada)
    float yDestino = puertaAbierta ? yInicial + anguloApertura : yInicial;

    // Creamos la rotación destino usando los valores iniciales de X y Z, y el valor destino de Y
    Quaternion rotacionDestino = Quaternion.Euler(xInicial, yDestino, zInicial);

    // Interpolamos la rotación actual hacia la rotación destino
    transform.localRotation = Quaternion.Slerp(transform.localRotation, rotacionDestino, velocidadRotacionPuerta * Time.deltaTime);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "TriggerPuerta")
    {
      AudioSource.PlayClipAtPoint(cerrarPuerta, transform.position, 1);
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.tag == "TriggerPuerta")
    {
      AudioSource.PlayClipAtPoint(abrirPuerta, transform.position, 1);
    }
  }
}
