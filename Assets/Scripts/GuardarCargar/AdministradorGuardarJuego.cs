using System;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorGuardarJuego : MonoBehaviour
{
  public static GuardarDato dato;
  public Transform jugadorTransform;

  private void Awake()
  {
    dato = new GuardarDato();
    GuardarCargar.CargarJuego += CargarDato;
  }

  public void EliminarDato()
  {
    GuardarCargar.EliminarDatoGuardado();
  }

  public static void GuardarDato()
  {
    var guardarDato = dato;
    var controladorNivel = FindObjectOfType<ControladorNivel>();
    var jugador = FindObjectOfType<PersonajeController>();

    guardarDato.nivelActual = controladorNivel.nivelActual;
    guardarDato.posicionJugador = jugador.transform.position;
    GuardarCargar.Guardar(guardarDato);
  }

  public static void CargarDato(GuardarDato _dato)
  {
    dato = _dato;
    var controladorNivel = FindObjectOfType<ControladorNivel>();
    var jugador = FindObjectOfType<PersonajeController>();

    controladorNivel.nivelActual = dato.nivelActual;
    foreach (var verificador in controladorNivel.verificadoresDeBasura)
    {
      verificador.resultados.Clear();
    }
    var nivelResultado = dato.resultadosPorNivel.Find(nr => nr.nivel == controladorNivel.nivelActual);
    if (nivelResultado != null)
    {
      foreach (var resultado in nivelResultado.resultados)
      {
        foreach (var verificador in controladorNivel.verificadoresDeBasura)
        {
          verificador.resultados[resultado.Tipo] = resultado;
        }
      }
    }
    jugador.transform.position = dato.posicionJugador;
    controladorNivel.ActivarCajasNivel(controladorNivel.nivelActual);
  }
  public static void ICargarDato()
  {
    GuardarCargar.Cargar();
  }
}
