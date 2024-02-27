using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Añade esta línea

public class SistemaVida : MonoBehaviour
{
    public float vida = 100;
    public Image BarraVida; // La barra de vida roja
    public Image Vida; // La barra de vida verde

    private float vidaAnterior;
    private bool estaVivo = true;

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

            if (vida <= 0 && estaVivo)
            {

                Animator anim = GetComponent<Animator>();
                anim.SetTrigger("morir");
                estaVivo = false;

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
