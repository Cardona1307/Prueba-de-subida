using UnityEngine;
using UnityEngine.UI;


public class SistemaVida : MonoBehaviour
{
    public float vida = 100;
    public Image BarraVida; // La barra de vida roja
    public Image Vida; // La barra de vida verde

    private float vidaAnterior;

    void Start()
    {
        vidaAnterior = vida;
        ActualizarBarraVida();
    }

    void Update()
    {
        if (vida != vidaAnterior)
        {
            vida = Mathf.Clamp(vida, 0, 100);
            ActualizarBarraVida();
            vidaAnterior = vida;

            // Verifica si la vida del jugador ha llegado a 0
            if (vida <= 0)
            {
                // Destruye el objeto del jugador
                Destroy(gameObject);
            }
        }
    }

    public void ActualizarBarraVida()
    {
        float vidaNormalizada = vida / 100;
        BarraVida.fillAmount = vidaNormalizada;
        Vida.fillAmount = vidaNormalizada;
    }
}
