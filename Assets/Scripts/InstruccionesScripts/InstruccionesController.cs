using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstruccionesController : MonoBehaviour
{
    public List<GameObject> paginasInstrucciones; // Lista de páginas de instrucciones
    public Button botonAtras;
    public Button botonSiguiente;
    public Button botonIrAlJuego;
    public Button botonVolver;
    
    private int paginaActual = 0;

    void Start()
    {
        ActualizarPagina();
        
        botonAtras.onClick.AddListener(Atras);
        botonSiguiente.onClick.AddListener(Siguiente);
        botonIrAlJuego.onClick.AddListener(IrAlJuego);
        botonVolver.onClick.AddListener(Volver);
    }

    void ActualizarPagina()
    {
        for (int i = 0; i < paginasInstrucciones.Count; i++)
        {
            paginasInstrucciones[i].SetActive(i == paginaActual);
        }

        // Mostrar u ocultar botones según la página actual
        botonAtras.gameObject.SetActive(paginaActual > 0);
        botonSiguiente.gameObject.SetActive(paginaActual < paginasInstrucciones.Count - 1);
        botonIrAlJuego.gameObject.SetActive(paginaActual == paginasInstrucciones.Count - 1);
    }

    void Atras()
    {
        if (paginaActual > 0)
        {
            paginaActual--;
            ActualizarPagina();
        }
    }

    void Siguiente()
    {
        if (paginaActual < paginasInstrucciones.Count - 1)
        {
            paginaActual++;
            ActualizarPagina();
        }
    }

    void IrAlJuego()
    {
        // Implementar lógica para ir al juego
    }

    void Volver()
    {
        // Implementar lógica para volver al menú principal u otra acción
    }
}
