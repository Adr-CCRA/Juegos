using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PuertaSeleccionada : MonoBehaviour
{
  public float distancia = 3f;

  void Update()
  {
    RaycastHit hit;

    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia))
    {
      if (hit.collider.tag == "Puerta")
      {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
          Debug.Log("tecla R presionado");
          PuertaController puerta = hit.collider.GetComponent<PuertaController>();
          if (puerta != null)
          {
            Debug.Log("PuertaController found");
            puerta.CambioEstadoPuerta();
          }
          else
          {
            Debug.Log("No PuertaController component found");
          }
        }
      }
    }
  }
}
