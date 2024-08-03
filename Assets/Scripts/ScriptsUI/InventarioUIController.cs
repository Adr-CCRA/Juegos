using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventarioUIController : MonoBehaviour
{
  public VisualizarInventarioDinamico inventarioPanel;
  public VisualizarInventarioDinamico mochilaPersonajePanel;

  private void Awake()
  {
    inventarioPanel.gameObject.SetActive(false);
    mochilaPersonajePanel.gameObject.SetActive(false);
  }

  private void OnEnable()
  {
    TitularInventario.visualizarInventarioDinamicoSolicitado += InventarioVisualizar;
    PersonajeTitularInventario.visualizarInventarioPersonajeSolicitado += InventarioJugadorVisualizar;
  }
  private void OnDisable()
  {
    TitularInventario.visualizarInventarioDinamicoSolicitado -= InventarioVisualizar;
    PersonajeTitularInventario.visualizarInventarioPersonajeSolicitado -= InventarioJugadorVisualizar;
  }
  public void Update()
  {
    if (inventarioPanel.gameObject.activeInHierarchy && Keyboard.current.spaceKey.wasPressedThisFrame)
    {
      inventarioPanel.gameObject.SetActive(false);
    }

    if (mochilaPersonajePanel.gameObject.activeInHierarchy && Keyboard.current.spaceKey.wasPressedThisFrame)
    {
      mochilaPersonajePanel.gameObject.SetActive(false);
    }
  }

  void InventarioVisualizar(SistemaInventario invVisualizar, int compensar)
  {
    inventarioPanel.gameObject.SetActive(true);
    inventarioPanel.ActualizarInventarioDinamico(invVisualizar, compensar);
  }
  void InventarioJugadorVisualizar(SistemaInventario invVisualizar, int compensar)
  {
    mochilaPersonajePanel.gameObject.SetActive(true);
    mochilaPersonajePanel.ActualizarInventarioDinamico(invVisualizar, compensar);
  }
  public void CerrarMochila()
  {
    mochilaPersonajePanel.gameObject.SetActive(false);
  }

  public void CerrarInventario()
  {
    inventarioPanel.gameObject.SetActive(false);
  }
}
