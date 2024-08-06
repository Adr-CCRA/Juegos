using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instancia;
    public Sonido [] musica, efectos;
    public AudioSource musicaSource, efxSource;

    private void Awake() {
        if(Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start() {
        PlayMusica("MusicaFondo");
    }
    public void PlayMusica (string nombre)
    {
        Sonido sonido = Array.Find(musica, x => x.nombre == nombre);
        if(sonido == null)
        {
            Debug.Log("No hay musica");
        }
        else 
        {
            musicaSource.clip = sonido.clip;
            musicaSource.Play();
        }
    }

    public void PlayEfecto (string nombre)
    {
        Sonido sonido = Array.Find(efectos, x => x.nombre == nombre);
        if(sonido == null)
        {
            Debug.Log("No hay musica");
        }
        else 
        {
            efxSource.PlayOneShot(sonido.clip);
        }
    }

    public void ActivarMusica()
    {
        musicaSource.mute = !musicaSource.mute;
    }
    public void ActivarEfecto()
    {
        efxSource.mute = !efxSource.mute;
    }
    public void VolumenMusica(float volumen)
    {
        musicaSource.volume = volumen;
    }
    public void VolumenEfecto(float volumen)
    {
        efxSource.volume = volumen;
    }
}
