using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventarioUIController : MonoBehaviour
{
  public VisualizarInventarioDinamico inventarioPanel;

  private void Awake() {
    inventarioPanel.gameObject.SetActive(false);
  }

  private void OnEnable() {
    TitularInventario.visualizarInventarioDinamicoSolicitado += InventarioVisualizar;
  }
  private void OnDisable() {
    TitularInventario.visualizarInventarioDinamicoSolicitado -= InventarioVisualizar;
  }
  void Update()
  {
    if(Keyboard.current.bKey.wasPressedThisFrame){
      InventarioVisualizar(new SistemaInventario(Random.Range(20, 30)));
    }
    if(inventarioPanel.gameObject.activeInHierarchy && Keyboard.current.spaceKey.wasPressedThisFrame){
      inventarioPanel.gameObject.SetActive(false);
    }
  }

  void InventarioVisualizar(SistemaInventario invVisualizar){
    inventarioPanel.gameObject.SetActive(true);
    inventarioPanel.ActualizarInventarioDinamico(invVisualizar);
  }
}
