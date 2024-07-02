using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaCambioColor : MonoBehaviour
{
    public GameObject objetoHijo; // Asignar el objeto hijo en el Inspector
    private Renderer objRenderer;
    private Color originalColor;
    private Color highlightColor = new Color(3, 63, 0);

    void Start()
    {
        if (objetoHijo != null)
        {
            objRenderer = objetoHijo.GetComponent<Renderer>();
            if (objRenderer != null)
            {
                originalColor = objRenderer.material.color;
            }
            else
            {
                Debug.LogError("El objeto hijo no tiene un componente Renderer.");
            }
        }
        else
        {
            Debug.LogError("No se ha asignado un objeto hijo.");
        }
    }

    public void Highlight(bool highlight)
    {
        if (objRenderer != null)
        {
            objRenderer.material.color = highlight ? highlightColor : originalColor;
        }
    }
}
