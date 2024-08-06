using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAudio : MonoBehaviour
{
    public Slider musicaSlider, efectoSlider;

    public void ActivarMusica()
    {
        AudioController.Instancia.ActivarMusica();
    }
    public void ActivarEfecto()
    {
        AudioController.Instancia.ActivarEfecto();
    }
    public void VolumenMusica()
    {
        AudioController.Instancia.VolumenMusica(musicaSlider.value);
    }
    public void VolumenEfecto()
    {
        AudioController.Instancia.VolumenEfecto(efectoSlider.value);
    }
}
