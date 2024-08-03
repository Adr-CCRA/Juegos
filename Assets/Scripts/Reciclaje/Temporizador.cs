using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    [SerializeField] public Text textoTiempo; // Texto UI para mostrar el tiempo
    [SerializeField] private Slider slider;
    public float tiempoLimite; // Tiempo límite en segundos (2 minutos)
    private float tiempoRestante;
    private bool contando;
    private int nivelActual;

    void Start()
    {
        tiempoRestante = tiempoLimite;
        contando = false;
    }

    void Update()
    {
        if (contando)
        {       
            // Debug.Log("pruebaTiempo: " + tiempoRestante);
            tiempoRestante -= Time.deltaTime;
            if(tiempoRestante >= 0) 
            {
                slider.value = tiempoRestante;
                
            }
            MostrarTiempo(tiempoRestante);

            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                contando = false;
                TiempoTerminado();
            }
        }
    }
    
    public void TemporizadoPorNivel(){
        nivelActual = AdministradorGuardarJuego.dato.nivelActual;
        if(nivelActual == 1)
        {
            tiempoLimite = 120f;
        }
        else
        {
            tiempoLimite = 880f;
        }
            tiempoRestante = tiempoLimite;
    }
    public void IniciarTemporizador()
    {
        TemporizadoPorNivel(); 
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
