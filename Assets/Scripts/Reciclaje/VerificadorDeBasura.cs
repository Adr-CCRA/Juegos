using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;
using System;
using System.Security.Cryptography;
using Unity.VisualScripting;

public class VerificadorDeBasura : MonoBehaviour
{
    public List<CajaReciclaje> cajasReciclaje; // Lista de todas las cajas de reciclaje en la escena
    public UnityEvent<string> onVerificacionCompletada; // Evento para mostrar el resultado de la verificación

    public Dictionary<string, ResultadosDato> resultados = new Dictionary<string, ResultadosDato>();
    public int totalElementosNivel = 8; // Número total de elementos en el nivel

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
                        onVerificacionCompletada.Invoke($"El elemento {ranura.DatosElemento.mostrarNombre}, {ranura.DatosElemento.Descripcion} está en la caja incorrecta. Debe ir a la caja de {caja.Tipo}.");
                        resultados[caja.Tipo].clasificacionIncorrecta++;
                    }
                }
            }
        }

        // Calcular el puntaje para cada tipo de basura
        int totalCajas = cajasReciclaje.Count;
        int elementosPorCaja = totalElementosNivel / totalCajas;
        foreach (var resultado in resultados.Values)
        {
            resultado.puntaje = CalcularPuntaje(elementosPorCaja, resultado.clasificacionCorrecta);
        }

        string mensaje = GenerarMensajeResultados();
        onVerificacionCompletada.Invoke(mensaje);

        GuardarResultados();
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

    public int CalcularPuntaje(int elementosPorCaja, int correcto)
    {
        if (elementosPorCaja == 0) return 0;
        float valorPorElemento = 100f / elementosPorCaja;
        return (int)(correcto * valorPorElemento);
    }

    public void GuardarResultados()
    {
        int nivelActual = FindObjectOfType<ControladorNivel>().nivelActual;
        var controladorNivel = FindObjectOfType<ControladorNivel>();

        // Combinar los resultados de todas las instancias de VerificadorDeBasura
        var resultadosCombinados = new Dictionary<string, ResultadosDato>();

        foreach (var verificador in controladorNivel.verificadoresDeBasura)
        {
            foreach (var kvp in verificador.resultados)
            {
                if (resultadosCombinados.ContainsKey(kvp.Key))
                {
                    resultadosCombinados[kvp.Key].totalElementos += kvp.Value.totalElementos;
                    resultadosCombinados[kvp.Key].clasificacionCorrecta += kvp.Value.clasificacionCorrecta;
                    resultadosCombinados[kvp.Key].clasificacionIncorrecta += kvp.Value.clasificacionIncorrecta;
                    resultadosCombinados[kvp.Key].puntaje = CalcularPuntaje(controladorNivel.verificadoresDeBasura[0].totalElementosNivel / controladorNivel.verificadoresDeBasura.Count, resultadosCombinados[kvp.Key].clasificacionCorrecta);
                }
                else
                {
                    resultadosCombinados[kvp.Key] = kvp.Value;
                }
            }
        }

        var resultadosList = new List<ResultadosDato>(resultadosCombinados.Values);

        // Verificar si ya existen resultados para el nivel actual
        var nivelResultado = AdministradorGuardarJuego.dato.resultadosPorNivel.Find(nr => nr.nivel == nivelActual);
        if (nivelResultado != null)
        {
            nivelResultado.resultados = resultadosList;
        }
        else
        {
            AdministradorGuardarJuego.dato.resultadosPorNivel.Add(new NivelResultado(nivelActual, resultadosList));
        }

        AdministradorGuardarJuego.GuardarDato();
    }


    public void ActualizarNivel(int nuevoNivel)
    {
        totalElementosNivel = (nuevoNivel == 2) ? 20 : 8; // Ajusta el número de elementos para el nivel
        resultados.Clear(); // Asegura que los resultados se reinicien al actualizar el nivel
        Debug.Log($"Estoy en nivel {nuevoNivel} de ActualizarNivel. Elementos a recolectar: {totalElementosNivel} resultados: {resultados.Values}");
    }
    [Serializable]
    public class ResultadosDato
    {
        public string Tipo;
        public int totalElementos;
        public int clasificacionCorrecta;
        public int clasificacionIncorrecta;
        public int puntaje;
        public class ListaResultados
        {
            public List<ResultadosDato> resultados;
        }
    }
}
