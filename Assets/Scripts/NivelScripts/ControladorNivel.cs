using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ControladorNivel : MonoBehaviour
{
    public List<VerificadorDeBasura> verificadoresDeBasura; // Cambiar a una lista
    public Temporizador temporizador;
    public int puntosParaPasar = 51;
    public PuertaController puertaCuarto;
    public PuertaController puertaPrincipal;
    public UIManager uiManager;
    public GameObject cajasNivel1;
    public GameObject cajasNivel2;

    public int nivelActual = 1;
    private bool nivelCompletado = false;

    private void Start()
    {
        foreach (var verificador in verificadoresDeBasura)
        {
            verificador.onVerificacionCompletada.AddListener(VerificarResultado);
        }
        temporizador.DetenerTemporizador();
        nivelActual = AdministradorGuardarJuego.dato.nivelActual;
        ActivarCajasNivel(nivelActual);
        CargarPuntajesPorNivel();
    }

    private void Update()
    {
        if (nivelActual == 2) puertaCuarto.puedeInteractuar = true;
    }

    private void VerificarResultado(string mensaje)
    {
        int puntaje = CalcularPuntajeTotal();
        float tiempo = temporizador.ObtenerTiempo();
        if (puntaje >= puntosParaPasar)
        {
            nivelCompletado = true;
            uiManager.MostrarPantallaVictoria(puntaje, tiempo);
            if (nivelActual == 1)
            {
                // Debug.Log("Nivel 1 completado");
                puertaCuarto.puedeInteractuar = true;
                puertaCuarto.puertaAbierta = true;
            }
            else if (nivelActual == 2)
            {
                // Debug.Log("Nivel 2 completado");
                puertaPrincipal.puedeInteractuar = true;
                uiManager.botonReintentar.gameObject.SetActive(true);
                uiManager.botonReintentar.GetComponentInChildren<TMP_Text>().text = "Volver a jugar";
                uiManager.botonContinuar.gameObject.SetActive(false);
            } 
            else if (nivelActual == 3)
            {
                Debug.Log("estoy en nivel 3");
            }

            GuardarResultadosDeTodasLasInstancias();
            GuardarNivel();
        }
        else
        {
            uiManager.MostrarPantallaDerrota(puntaje, tiempo);
        }
    }

    public int CalcularPuntajeTotal()
    {
        int puntajeTotal = 0;
        int cantidadTipos = 0;

        foreach (var verificador in verificadoresDeBasura)
        {
            cantidadTipos += verificador.resultados.Count;
            foreach (var resultado in verificador.resultados.Values)
            {
                puntajeTotal += resultado.puntaje;
            }
        }

        if (cantidadTipos == 0) return 0;
        return puntajeTotal / cantidadTipos;
    }

    public void AvanzarNivel()
    {
        if (nivelCompletado)
        {
            nivelActual++;
            foreach (var verificador in verificadoresDeBasura)
            {
                verificador.ActualizarNivel(nivelActual);
            }
            nivelCompletado = false;
            ReiniciarPuntajeYTiempo();
            ActivarCajasNivel(nivelActual);
            GuardarNivel();
        }
    }

    private void ReiniciarPuntajeYTiempo()
    {
        foreach (var verificador in verificadoresDeBasura)
        {
            verificador.resultados.Clear();
        }
        temporizador.ReiniciarTemporizador();
    }

    public void ActivarCajasNivel(int nivel)
    {
        cajasNivel1.SetActive(nivel == 1);
        cajasNivel2.SetActive(nivel == 2);
    }

    public void IniciarNivel()
    {
        nivelCompletado = false;
        temporizador.IniciarTemporizador();
    }

    public void ReiniciarNivel()
    {
        nivelCompletado = false;
        foreach (var verificador in verificadoresDeBasura)
        {
            verificador.ActualizarNivel(nivelActual);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        temporizador.IniciarTemporizador();

        var jugador = FindObjectOfType<PersonajeController>();
        jugador.transform.position = AdministradorGuardarJuego.dato.posicionJugador;
        ActivarCajasNivel(nivelActual);
    }

    private void GuardarNivel()
    {
        GuardarResultadosDeTodasLasInstancias();
        AdministradorGuardarJuego.dato.nivelActual = nivelActual;
        AdministradorGuardarJuego.GuardarDato();
    }

    private void CargarPuntajesPorNivel()
    {
        var nivelResultado = AdministradorGuardarJuego.dato.resultadosPorNivel.Find(nr => nr.nivel == nivelActual);
        foreach (var verificador in verificadoresDeBasura)
        {
            verificador.resultados.Clear();
        }
        if (nivelResultado != null)
        {
            var resultadosCombinados = new Dictionary<string, VerificadorDeBasura.ResultadosDato>();
            foreach (var resultado in nivelResultado.resultados)
            {
                if (resultadosCombinados.ContainsKey(resultado.Tipo))
                {
                    resultadosCombinados[resultado.Tipo].totalElementos += resultado.totalElementos;
                    resultadosCombinados[resultado.Tipo].clasificacionCorrecta += resultado.clasificacionCorrecta;
                    resultadosCombinados[resultado.Tipo].clasificacionIncorrecta += resultado.clasificacionIncorrecta;
                    resultadosCombinados[resultado.Tipo].puntaje = verificadoresDeBasura[0].CalcularPuntaje(resultadosCombinados[resultado.Tipo].totalElementos, resultadosCombinados[resultado.Tipo].clasificacionCorrecta);
                }
                else
                {
                    resultadosCombinados[resultado.Tipo] = resultado;
                }
            }

            foreach (var verificador in verificadoresDeBasura)
            {
                foreach (var kvp in resultadosCombinados)
                {
                    verificador.resultados[kvp.Key] = kvp.Value;
                }
            }
        }
    }

    private void GuardarResultadosDeTodasLasInstancias()
    {
        foreach (var verificador in verificadoresDeBasura)
        {
            verificador.GuardarResultados();
        }
    }
}
