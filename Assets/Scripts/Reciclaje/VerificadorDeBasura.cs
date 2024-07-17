using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Linq;

public class VerificadorDeBasura : MonoBehaviour
{
    public List<CajaReciclaje> cajasReciclajeNivel1; // Lista de cajas de reciclaje para nivel 1
    public List<CajaReciclaje> cajasReciclajeNivel2; // Lista de cajas de reciclaje para nivel 2
    public UnityEvent<string> onVerificacionCompletada; // Evento para mostrar el resultado de la verificación
    public UnityEvent<string> onVerificacionElementos;
    public UnityEvent<string> onVerificacionIncorrecto;
    public Dictionary<string, ResultadosDato> resultados = new Dictionary<string, ResultadosDato>();
    public int totalElementosNivel; // Número total de elementos en el nivel

    private int nivelActual; // Nivel actual a verificar

    private void Update() {
        nivelActual = AdministradorGuardarJuego.dato.nivelActual;
        ActualizarNivel(nivelActual);
        string mensajeElementos = $"Recolectar: {totalElementosNivel}";
        onVerificacionElementos.Invoke(mensajeElementos);
    }

    public void VerificarBasura()
    {
        resultados.Clear();

        List<CajaReciclaje> cajasReciclaje = null;

        if (nivelActual == 1)
        {
            cajasReciclaje = cajasReciclajeNivel1;
        }
        else if (nivelActual == 2)
        {
            cajasReciclaje = cajasReciclajeNivel2;
        }

        if (cajasReciclaje == null || cajasReciclaje.Count == 0)
        {
            Debug.LogError("No hay cajas de reciclaje asignadas para el nivel actual.");
            return;
        }

        foreach (var caja in cajasReciclaje)
        {
            if (caja == null)
            {
                Debug.LogError("Caja de reciclaje nula encontrada.");
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
                        onVerificacionIncorrecto.Invoke($"La basura {ranura.DatosElemento.mostrarNombre} esta en el contenedor incorrecto, {ranura.DatosElemento.Descripcion}");
                        Debug.Log($"El elemento {ranura.DatosElemento.mostrarNombre}, {ranura.DatosElemento.Descripcion} está en la caja incorrecta.");
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
        Debug.Log(mensaje);

        GuardarResultados();
    }


    private string GenerarMensajeResultados()
    {
        string mensaje = "";
        foreach (var resultado in resultados.Values)
        {
            if (resultado.clasificacionIncorrecta > 0)
                {
                    mensaje += $"{resultado.Tipo}  es incorrecto\n";
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
                    resultadosCombinados[kvp.Key].puntaje = CalcularPuntaje(resultadosCombinados[kvp.Key].totalElementos, resultadosCombinados[kvp.Key].clasificacionCorrecta);
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
        totalElementosNivel = (nuevoNivel == 2) ? 32 : 8; // Ajusta el número de elementos para el nivel
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
