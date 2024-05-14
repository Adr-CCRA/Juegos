using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public interface Interactuable
{
  public UnityAction<Interactuable> InteraccionCompleta { get; set; }
  public void  Interactuar(Interactor interactor, out bool interactuarExitoso);
  public void FinInteraccion();
}
