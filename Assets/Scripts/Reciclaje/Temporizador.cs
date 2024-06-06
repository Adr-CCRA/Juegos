using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    [SerializeField] public Text textoTiempo; // Texto UI para mostrar el tiempo
    [SerializeField] private Slider slider;
    public float tiempoLimite = 120f; // Tiempo límite en segundos (2 minutos)
    private float tiempoRestante;
    private bool contando;

    void Start()
    {
        tiempoRestante = tiempoLimite;
        contando = false;
    }

    void Update()
    {
        if (contando)
        {
            tiempoRestante -= Time.deltaTime;
            if(tiempoRestante >= 0) 
            {
                slider.value = tiempoRestante;
                
            }
            MostrarTiempo(tiempoRestante);
            // slider.maxValue = tiempoRestante;

            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                contando = false;
                TiempoTerminado();
            }
        }
    }

    public void IniciarTemporizador()
    {
        tiempoRestante = tiempoLimite;
        contando = true;
    }

    public void DetenerTemporizador()
    {
        contando = false;
    }

    public void ReiniciarTemporizador()
    {
        tiempoRestante = tiempoLimite;
        contando = false;
        MostrarTiempo(tiempoRestante);
        // slider.maxValue = tiempoRestante;
    }

    void MostrarTiempo(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60F);
        int segundos = Mathf.FloorToInt(tiempo % 60F);
        // int milisegundos = Mathf.FloorToInt((tiempo * 1000F) % 1000F);
        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        slider.maxValue = tiempoLimite;
    }

    public float ObtenerTiempo()
    {
        return tiempoRestante;
    }

    private void TiempoTerminado()
    {
        FindObjectOfType<UIManager>().MostrarPantallaDerrota(FindObjectOfType<ControladorNivel>().CalcularPuntajeTotal(), tiempoLimite - tiempoRestante);
    }
}
