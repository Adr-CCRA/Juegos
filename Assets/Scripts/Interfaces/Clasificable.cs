using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public interface Clasificable
{
  public UnityAction<Clasificable> ClasificacionCompleta { get; set; }
  public void Clasificar(Clasificador clasificador, out bool clasificacionExitosa);
  public void FinClasificacion();
}
