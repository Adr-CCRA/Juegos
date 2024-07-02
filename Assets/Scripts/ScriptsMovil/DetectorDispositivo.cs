using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorDispositivo : MonoBehaviour
{
    public GameObject controlesMovil; // Contenedor para los controles móviles

    void Start()
    {
        #if UNITY_IOS || UNITY_ANDROID
            HabilitarControlesMovil();
        #else
            InhabilitarControlesMovil();
        #endif
    }

    void HabilitarControlesMovil()
    {
        controlesMovil.SetActive(true);
    }

    void InhabilitarControlesMovil()
    {
        controlesMovil.SetActive(false);
    }
}
