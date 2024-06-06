using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GuardarDato
{
  public List<string> colectarElementos;
  public SerializableDiccionario<string, GuardarDatosElementoRecogidos> activarElementos;
  public SerializableDiccionario<string, GuardarDatosCaja> cajaDiccionario;
  public GuardarDatosCaja inventarioPersonje;
  public int nivelActual;
  public Vector3 posicionJugador;
  public List<NivelResultado> resultadosPorNivel;

  public GuardarDato()
  {
    colectarElementos = new List<string>();
    activarElementos = new SerializableDiccionario<string, GuardarDatosElementoRecogidos>();
    cajaDiccionario = new SerializableDiccionario<string, GuardarDatosCaja>();
    inventarioPersonje = new GuardarDatosCaja();
    nivelActual = 1;
    posicionJugador = Vector3.zero;
    resultadosPorNivel = new List<NivelResultado>();
  }
}

[Serializable]
public class NivelResultado
{
  public int nivel;
  public List<VerificadorDeBasura.ResultadosDato> resultados;

  public NivelResultado(int nivel, List<VerificadorDeBasura.ResultadosDato> resultados)
  {
    this.nivel = nivel;
    this.resultados = resultados;
  }
}
