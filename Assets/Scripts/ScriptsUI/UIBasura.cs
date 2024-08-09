using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIBasura : MonoBehaviour
{
    public GameObject nivel1;
    public GameObject nivel2;
    public GameObject DatosBasura;
    public static GuardarDato dato;
    public bool basura = false;
    public Button botonBasura;

    private void Start()
    {
        Debug.Log("UIBasura script initialized.");
        DatosBasura.SetActive(false);
        botonBasura.onClick.AddListener(MostrarDatosBasura);
    }

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Debug.Log("Tecla Q presionada");
            MostrarDatosBasura();
        }
        DatosRecoleccionPorNivel();
    }

    public void DatosRecoleccionPorNivel()
    {
        var controladorNivel = FindObjectOfType<ControladorNivel>();
        if (controladorNivel == null)
        {
            Debug.LogError("La referencia 'controladorNivel' no está asignada.");
            return;
        }

        Debug.Log("Nivel: " + controladorNivel.nivelActual);
        if (controladorNivel.nivelActual == 1)
        {
            nivel1.SetActive(true);
            nivel2.SetActive(false);
        }
        else
        {
            nivel1.SetActive(false);
            nivel2.SetActive(true);
        }
    }

    public void MostrarDatosBasura()
    {
        if (basura == false)
        {
            DatosBasura.SetActive(true);
            basura = true;
        }
        if (basura)
        {
            DatosBasura.transform.SetAsLastSibling(); // Poner al frente de todo
        }
    }
    public void Cerrar()
    {
        DatosBasura.SetActive(false);
        basura = false;
    }
}
