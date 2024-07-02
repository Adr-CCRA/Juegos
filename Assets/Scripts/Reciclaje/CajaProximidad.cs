using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaProximidad : MonoBehaviour
{
    public Transform PuntoInteraccion;
    public LayerMask CapaInteraccion;
    public float PuntoRadioInteraccion = 1f;

    private List<CajaCambioColor> objetosCercanos = new List<CajaCambioColor>();

    private void Update() 
    {
        var colisiones = Physics.OverlapSphere(PuntoInteraccion.position, PuntoRadioInteraccion, CapaInteraccion);
        List<CajaCambioColor> nuevosObjetosCercanos = new List<CajaCambioColor>();

        for (int i = 0; i < colisiones.Length; i++)
        {
            var CajaCambioColor = colisiones[i].GetComponent<CajaCambioColor>();
            if (CajaCambioColor != null)
            {
                nuevosObjetosCercanos.Add(CajaCambioColor);
                if (!objetosCercanos.Contains(CajaCambioColor))
                {
                    CajaCambioColor.Highlight(true);
                }
            }
        }

        foreach (var obj in objetosCercanos)
        {
            if (!nuevosObjetosCercanos.Contains(obj))
            {
                obj.Highlight(false);
            }
        }

        objetosCercanos = nuevosObjetosCercanos;
    }
}
