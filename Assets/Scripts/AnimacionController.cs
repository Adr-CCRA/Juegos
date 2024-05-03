using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionController : MonoBehaviour
{
  Animator animador;
  Rigidbody rb;
  float velocidadMaxima = 5f;
   private void Start() {
    animador = this.GetComponent<Animator>();
    rb = this.GetComponent<Rigidbody>();
   }
   private void Update() {
    float magnitudVelocidad = rb.velocity.magnitude;
    Debug.Log("Magnitud de la velocidad: " + magnitudVelocidad);
    animador.SetFloat("Velocidad", magnitudVelocidad / velocidadMaxima);
   }
}
