using UnityEngine;
using UnityEngine.UI;


public class Linterna : MonoBehaviour
{
    public Light luz;
    public float tiempoEncendido = 5f;
    public float tiempoEspera = 60f;
    private bool estaEncendida = false;
    private float tiempoCooldown;

    // Referencia a la barra amarilla (debe ser un Image en la jerarquía)
    public Image BarraLuz;

    private float tiempoInicioUso; // Nuevo
    private float tiempoInicioCooldown; // Nuevo

    void Start()
    {
        luz = GetComponent<Light>();
        luz.enabled = false;
        tiempoCooldown = Time.time;
        tiempoInicioCooldown = Time.time; // Nuevo
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && Time.time >= tiempoCooldown)
        {
            if (!estaEncendida)
            {
                EncenderLuz();
                tiempoInicioUso = Time.time; // Nuevo
            }
            tiempoCooldown = Time.time + tiempoEspera;
            tiempoInicioCooldown = Time.time; // Nuevo
        }

        if (estaEncendida)
        {
            tiempoEncendido -= Time.deltaTime;
            float fillAmount = Mathf.Clamp01(tiempoEncendido / 5f); // Normaliza entre 0 y 1
            BarraLuz.fillAmount = fillAmount;

            if (tiempoEncendido <= 0)
            {
                ApagarLuz();
            }
        }
        else if (TiempoRecargaRestante() > 0)
        {
            // Mostrar la recarga en la barra
            float tiempoRecargaPasado = Time.time - tiempoInicioCooldown; // Nuevo
            float fillAmount = Mathf.Clamp01(tiempoRecargaPasado / tiempoEspera); // Nuevo
            BarraLuz.fillAmount = fillAmount;
        }
    }

    public void EncenderLuz()
    {
        luz.enabled = true;
        estaEncendida = true;
        tiempoEncendido = 5f;
    }

    public void ApagarLuz()
    {
        luz.enabled = false;
        estaEncendida = false;
    }

    private float TiempoRecargaRestante()
    {
        return tiempoCooldown - Time.time;
    }
}
