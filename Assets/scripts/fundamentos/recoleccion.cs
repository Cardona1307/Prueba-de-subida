using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class recoleccion : MonoBehaviour
{
    public int monedasRecogidas = 0;
    public TextMeshProUGUI puntajeMonedas;
    public TextMeshProUGUI textoVictoria;
    public int objetivoVictoria = 7;

    void Start()
    {
        textoVictoria.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("moneda"))
        {
            Destroy(other.gameObject);
            monedasRecogidas++;
            puntajeMonedas.text =  monedasRecogidas.ToString();

            if (monedasRecogidas >= objetivoVictoria)
            {
                textoVictoria.gameObject.SetActive(true);
                textoVictoria.text = "¡Victoria!";
            }
        }
    }
}
