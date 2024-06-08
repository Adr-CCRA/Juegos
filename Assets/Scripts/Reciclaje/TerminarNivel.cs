using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminarNivel : MonoBehaviour
{
    public List<VerificadorDeBasura> verificadoresDeBasura;
    public Button botonGuardar;
    public Text resultadoTexto;
    public Text puntajeTexto;
    public int nivelActual;

    private void Start()
    {
        botonGuardar.onClick.AddListener(VerificarBasuraNivelActual);
        nivelActual = AdministradorGuardarJuego.dato.nivelActual;
    }
    private void Update() {
        nivelActual = AdministradorGuardarJuego.dato.nivelActual;
    }
    private void VerificarBasuraNivelActual()
    {
        foreach (var verificador in verificadoresDeBasura)
        {
            verificador.VerificarBasura();
            verificador.onVerificacionCompletada.AddListener(MostrarResultado);
        }

        GuardarResultadosDeTodasLasInstancias();
    }

    private void GuardarResultadosDeTodasLasInstancias()
    {
        MostrarResultado();
    }
    private void MostrarResultado(string mensaje)
    {
        resultadoTexto.text = mensaje;
        MostrarResultado();
    }

    public void MostrarResultado()
    {
        // string mensaje = "";
        int puntajeTotal = 0;
        int cantidadTipos = 0;

        foreach (var verificador in verificadoresDeBasura)
        {
            cantidadTipos += verificador.resultados.Count;
            foreach (var resultado in verificador.resultados.Values)
            {
                puntajeTotal += resultado.puntaje;
            }
        }

        // resultadoTexto.text = mensaje;
        puntajeTexto.text = $"Puntaje: {puntajeTotal / cantidadTipos}";
    }
}
