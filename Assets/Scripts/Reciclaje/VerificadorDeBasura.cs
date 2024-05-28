using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

public class VerificadorDeBasura : MonoBehaviour
{
    public List<CajaReciclaje> cajasReciclaje; // Lista de todas las cajas de reciclaje en la escena
    public UnityEvent<string> onVerificacionCompletada; // Evento para mostrar el resultado de la verificación

    private Dictionary<string, ResultadosDato> resultados = new Dictionary<string, ResultadosDato>();

    public void VerificarBasura()
    {
        resultados.Clear();

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

            if (!resultados.ContainsKey(caja.Tipo))
            {
                resultados[caja.Tipo] = new ResultadosDato { Tipo = caja.Tipo };
            }

            foreach (var ranura in caja.SistemaInventario.InvetarioRanuras)
            {
                if (ranura.DatosElemento != null)
                {
                    resultados[caja.Tipo].totalElementos++;
                    if (ranura.DatosElemento.IDTipo == caja.IDTipoCaja)
                    {
                        resultados[caja.Tipo].clasificacionCorrecta++;
                    }
                    else
                    {
                        onVerificacionCompletada.Invoke($"El elemento {ranura.DatosElemento.mostrarNombre}, {ranura.DatosElemento.Descripcion}  está en la caja incorrecta. Debe ir a la caja de {caja.Tipo}.");
                        resultados[caja.Tipo].clasificacionIncorrecta++;
                    }
                }
            }
        }

        // Calcular el puntaje para cada tipo de basura
        foreach (var resultado in resultados.Values)
        {
            resultado.puntaje = CalcularPuntaje(resultado.totalElementos, resultado.clasificacionCorrecta);
        }

        GuardarResultados();
        string mensaje = GenerarMensajeResultados();
        onVerificacionCompletada.Invoke(mensaje);
    }

    private string GenerarMensajeResultados()
    {
        string mensaje = "";
        foreach (var resultado in resultados.Values)
        {
            if (resultado.clasificacionIncorrecta > 0)
            {
                mensaje += $"{resultado.Tipo} tiene {resultado.clasificacionIncorrecta} incorrectos.\n";
            }
            else
            {
                mensaje += $"{resultado.Tipo} correcto.\n";
            }
        }
        return mensaje;
    }

    private int CalcularPuntaje(int total, int correcto)
    {
        if (total == 0) return 0;
        return (int)((float)correcto / total * 100);
    }

    private void GuardarResultados()
    {
        string path = Path.Combine(Application.persistentDataPath, "resultadosNivel.json");
        List<ResultadosDato> listaResultados = new List<ResultadosDato>(resultados.Values);
        string json = JsonUtility.ToJson(new ListaResultados { resultados = listaResultados }, true);
        File.WriteAllText(path, json);
        Debug.Log($"Resultados guardados en: {path}");
    }

    [System.Serializable]
    public class ResultadosDato
    {
        public string Tipo;
        public int totalElementos;
        public int clasificacionCorrecta;
        public int clasificacionIncorrecta;
        public int puntaje;
    }

    [System.Serializable]
    public class ListaResultados
    {
        public List<ResultadosDato> resultados;
    }
}
