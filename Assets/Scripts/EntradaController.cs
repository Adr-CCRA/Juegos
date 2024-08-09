using UnityEngine;
using UnityEngine.InputSystem;

public class EntradaController : MonoBehaviour
{
    ActionAssets actionAssets;
    Vector2 entradaCamara;
    public float entradaCamaraX;
    public float entradaCamaraY;

    private void OnEnable()
    {
        if (actionAssets == null)
        {
            actionAssets = new ActionAssets();
            actionAssets.Personaje.Camara.performed += i => entradaCamara = i.ReadValue<Vector2>();
        }
        actionAssets.Enable();
    }

    private void Update()
    {
        // Actualizar los valores de entrada de la cámara en cada frame
        entradaCamaraX = entradaCamara.x;
        entradaCamaraY = entradaCamara.y;
    }
}
