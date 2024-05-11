using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO.Compression;
using UnityEngine.PlayerLoop;
using Unity.VisualScripting;
public class RaunuraInventarioUI : MonoBehaviour
{
  [SerializeField] private Image elementoSprite;
  [SerializeField] private TextMeshProUGUI elementoContador;
  [SerializeField] private InvetarioRanura asignarInventarioRanura;
  private Button boton;
  public InvetarioRanura AsignacionInventarioRanura => asignarInventarioRanura;
  public VisualizarInventario PadreVisualizar { get; private set; }

  private void Awake() {
    LimpiarRanura();

    boton = GetComponent<Button>();
    boton?.onClick.AddListener(RanuraUIClick);
    PadreVisualizar = transform.parent.GetComponent<VisualizarInventario>();
  }
  public void Inicia(InvetarioRanura ranura){
    asignarInventarioRanura = ranura;
    ActualizarUIRanura(ranura);
  }
  public void ActualizarUIRanura(InvetarioRanura ranura){
    if(ranura.DatosElemento != null){
      elementoSprite.sprite = ranura.DatosElemento.icono;
      elementoSprite.color = Color.white;

      if(ranura.CapacidadPila > 1) elementoContador.text = ranura.CapacidadPila.ToString();
      else elementoContador.text = "";
    } else{
      LimpiarRanura();
    }
  }

  public void ActualizarUIRanura(){
    if(asignarInventarioRanura != null){
      ActualizarUIRanura(asignarInventarioRanura);
    }
  }
  public void LimpiarRanura(){
    asignarInventarioRanura?.LimpiarRanura();
    elementoSprite.sprite =  null;
    elementoSprite.color = Color.clear;
    elementoContador.text = "";
  }
  public void RanuraUIClick(){
    PadreVisualizar?.RanuraClicked(this);
  }
}
