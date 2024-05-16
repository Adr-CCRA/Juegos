using UnityEngine;
using UnityEngine.InputSystem;

public class Clasificador : MonoBehaviour
{
  public Transform PuntoInteraccion;
  public LayerMask CapaInteraccion;
  public float PuntoRadioInteraccion = 1f;
  public bool Clasificando { get; set; }

  private void Update()
  {
    var colisiones = Physics.OverlapSphere(PuntoInteraccion.position, PuntoRadioInteraccion, CapaInteraccion);

    if (Keyboard.current.fKey.wasPressedThisFrame)
    {
      for (int i = 0; i < colisiones.Length; i++)
      {
        var clasificable = colisiones[i].GetComponent<Clasificable>();
        if (clasificable != null)
        {
          IniciarInteraccion(clasificable);
        }
      }
    }
  }

  void IniciarInteraccion(Clasificable clasificable)
  {
    clasificable.Clasificar(this, out bool clasificacionExitosa);
    Clasificando = true;
  }
  void FinInteraccion()
  {
    Clasificando = false;
  }

}
