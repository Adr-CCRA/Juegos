using UnityEngine;
using UnityEngine.InputSystem;

public class PuertaSeleccionada : MonoBehaviour
{
  public float distancia = 3f;
  public UIBotonPuerta uiBotonPuerta; // Referencia al script UIBotonPuerta

  void Update()
  {
    if (Keyboard.current.rKey.wasPressedThisFrame)
    {
      Debug.Log("Tecla R presionada");
      InteractuarPuerta();
    }
  }

  public void InteractuarPuerta()
  {
    RaycastHit hit;

    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia))
    {
      if (hit.collider.tag == "Puerta")
      {
        PuertaController puerta = hit.collider.GetComponent<PuertaController>();
        if (puerta != null)
        {
          Debug.Log("PuertaController encontrado");
          puerta.CambioEstadoPuerta();
          if (uiBotonPuerta != null)
          {
            uiBotonPuerta.ActualizarEstadoPuerta(puerta.puertaAbierta);
          }
        }
        else
        {
          Debug.Log("No se encontró el componente PuertaController");
        }
      }
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Puerta"))
    {
      PuertaController puerta = other.GetComponent<PuertaController>();
      if (puerta != null && uiBotonPuerta != null)
      {
        uiBotonPuerta.ActualizarEstadoPuerta(puerta.puertaAbierta);
      }
    }
  }
}
