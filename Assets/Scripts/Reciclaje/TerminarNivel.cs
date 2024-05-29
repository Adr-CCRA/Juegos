using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminarNivel : MonoBehaviour
{
    public VerificadorDeBasura verificadorDeBasura;
    public Button botonGuardar;
    public Text resultadoTexto;
    public Text puntajeTexto;

    private void Start()
    {
        botonGuardar.onClick.AddListener(verificadorDeBasura.VerificarBasura);
        verificadorDeBasura.onVerificacionCompletada.AddListener(MostrarResultado);
    }

    private void MostrarResultado(string mensaje)
    {
        resultadoTexto.text = mensaje;
        ActualizarPuntajeTexto();
    }

    private void ActualizarPuntajeTexto()
    {
        int puntajeTotal = 0;
        foreach (var resultado in verificadorDeBasura.resultados.Values)
        {
            puntajeTotal += resultado.puntaje;
        }
        puntajeTexto.text = $"Puntaje: {puntajeTotal}";
    }
}
