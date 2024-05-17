using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TitularInventario : MonoBehaviour
{
  [SerializeField] private int capacidadInventario;
  [SerializeField] protected SistemaInventario sistemaInventario;

  public SistemaInventario SistemaInventario => sistemaInventario;

  public static UnityAction<SistemaInventario> visualizarInventarioDinamicoSolicitado;

  protected virtual void Awake() {
    sistemaInventario = new SistemaInventario(capacidadInventario);
  }
}
