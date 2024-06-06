using System;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public static class GuardarCargar
{
  public static UnityAction GuardarJuego;
  public static UnityAction<GuardarDato> CargarJuego;

  private static string direccion = "/GuardarDato/";
  private static string nombreArchivo = "GuardarJuego.sav";

  public static bool Guardar(GuardarDato dato)
  {
    GuardarJuego?.Invoke();
    // BUSCA LA DIRECCION DE LA CARPETA
    string dir = Application.persistentDataPath + direccion;

    // GUIUtility.systemCopyBuffer = dir;
    // VERIFICA SI EXISTE LA DIRECCION DE LA CARPETA
    if (!Directory.Exists(dir))
    {
      Directory.CreateDirectory(dir);
    }

    string json = JsonUtility.ToJson(dato, true);
    File.WriteAllText(dir + nombreArchivo, json);

    Debug.Log("Juego Guardado");
    return true;
  }

  public static GuardarDato Cargar()
  {
    string rutaCompleta = Application.persistentDataPath + direccion + nombreArchivo;
    GuardarDato dato = new GuardarDato();
    // si el dato existe se obtiene el archivo y se vuelve a convertir en cadena
    if (File.Exists(rutaCompleta))
    {
      string json = File.ReadAllText(rutaCompleta);
      dato = JsonUtility.FromJson<GuardarDato>(json);
      CargarJuego?.Invoke(dato);
    }
    else
    {
      Debug.Log("Guardar archivo no existe!!!");
    }

    return dato;
  }

  public static void EliminarDatoGuardado()
  {
    string rutaCompleta = Application.persistentDataPath + direccion + nombreArchivo;
    if (File.Exists(rutaCompleta))
    {
      File.Delete(rutaCompleta);
    }
  }
}
