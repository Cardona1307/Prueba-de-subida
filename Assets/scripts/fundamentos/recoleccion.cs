using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class recoleccion : MonoBehaviour
{
    public int monedasRecogidas = 0;
    public TextMeshProUGUI puntajeMonedas;
    public GameObject panelVictoria; // Referencia al panel de victoria (asigna en el Inspector)
    public TextMeshProUGUI textoVictoria;
    public int objetivoVictoria = 10;

    private bool victoriaAlcanzada = false;

    // Variable pública para asignar el panel a desactivar desde el Inspector
    public GameObject UIgameplay; // Asigna el objeto de la interfaz de usuario aquí

    void Start()
    {
        panelVictoria.SetActive(false); // Ocultar el panel al inicio
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("moneda"))
        {
            Destroy(other.gameObject);
            monedasRecogidas++;
            puntajeMonedas.text = monedasRecogidas.ToString();

            if (monedasRecogidas >= objetivoVictoria && !victoriaAlcanzada)
            {
                // Detener el tiempo
                Time.timeScale = 0f;

                // Mostrar el panel de victoria
                panelVictoria.SetActive(true);
                textoVictoria.text = "¡Victoria!";
                victoriaAlcanzada = true;

                // Desactivar la UI del juego
                if (UIgameplay != null)
                {
                    UIgameplay.SetActive(false);
                }

                // Reactivar el cursor
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
