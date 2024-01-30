using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class fantasma : MonoBehaviour
{
    public float velocidad = 5f;
    public float distanciaAtaque = 1f;
    public float da�o = 1f;
    private Transform jugador;
    private SistemaVida sistemaVidaJugador;
    private Rigidbody rb;
    private float vidaAnterior;

    void Start()
    {
        // Encuentra al jugador en la escena usando la etiqueta y obt�n el componente SistemaVida
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform;
        sistemaVidaJugador = jugador.GetComponent<SistemaVida>();
        vidaAnterior = sistemaVidaJugador.vida;

        // Obt�n el componente Rigidbody y config�ralo para ignorar la f�sica
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        // Mueve al fantasma hacia el jugador
        Vector3 direccion = (jugador.position - transform.position).normalized;
        rb.MovePosition(transform.position + direccion * velocidad * Time.deltaTime);

        // Rota al fantasma para que mire hacia el jugador
        Quaternion rotacion = Quaternion.LookRotation(direccion);
        rb.MoveRotation(rotacion);

        // Si el fantasma est� lo suficientemente cerca del jugador, haz da�o
        if (Vector3.Distance(transform.position, jugador.position) <= distanciaAtaque)
        {
            sistemaVidaJugador.vida -= da�o * Time.deltaTime;
            if (sistemaVidaJugador.vida != vidaAnterior)
            {
                sistemaVidaJugador.ActualizarBarraVida();
                vidaAnterior = sistemaVidaJugador.vida;
            }
        }
    }
}
