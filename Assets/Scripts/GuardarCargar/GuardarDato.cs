using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarDato
{
  public List<string> colectarElementos;
  public SerializableDiccionario<string, GuardarDatosElementoRecogidos> activarElementos;
  public SerializableDiccionario<string, GuardarDatosCaja> cajaDiccionario;

  public GuardarDatosCaja inventarioPersonje;

  public GuardarDato(){
    colectarElementos = new List<string>();
    activarElementos = new SerializableDiccionario<string, GuardarDatosElementoRecogidos>();
    cajaDiccionario = new SerializableDiccionario<string, GuardarDatosCaja>();
    inventarioPersonje = new GuardarDatosCaja();
  } 
}
