using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VerificadorDeBasura : MonoBehaviour
{
    public List<CajaReciclaje> cajasReciclaje; // Lista de todas las cajas de reciclaje en la escena
    public UnityEvent<string> onVerificacionCompletada; // Evento para mostrar el resultado de la verificación

    public void VerificarBasura()
    {
        if (cajasReciclaje == null || cajasReciclaje.Count == 0)
        {
            Debug.LogError("No hay cajas de reciclaje asignadas.");
            return;
        }

        for (int i = 0; i < cajasReciclaje.Count; i++)
        {
            var caja = cajasReciclaje[i];
            if (caja == null)
            {
                Debug.LogError($"La caja de reciclaje en la posición {i} es null.");
                continue;
            }

            if (caja.SistemaInventario == null)
            {
                Debug.LogError($"La caja {caja.Tipo} no tiene un sistema de inventario asignado.");
                continue;
            }

            foreach (var ranura in caja.SistemaInventario.InvetarioRanuras)
            {
                if (ranura.DatosElemento != null)
                {
                    if (ranura.DatosElemento.IDTipo != caja.IDTipoCaja)
                    {
                        onVerificacionCompletada.Invoke($"El elemento {ranura.DatosElemento.mostrarNombre}, {ranura.DatosElemento.Descripcion}  está en la caja incorrecta. Debe ir a la caja de {caja.Tipo}.");
                        return;
                    }
                }
            }
        }
        onVerificacionCompletada.Invoke("¡Felicitaciones! Todos los elementos están en las cajas correctas.");
    }

}
