using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma : MonoBehaviour
{
    public float velocidad = 5f;
    public float distanciaAtaque = 1f;
    public float daño = 1f;
    private Transform jugador;
    private SistemaVida sistemaVidaJugador;
    private Rigidbody rb;
    private float vidaAnterior;

    void Start()
    {
        // Find the player in the scene using the tag and get the SistemaVida component
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform;
        sistemaVidaJugador = jugador.GetComponent<SistemaVida>();
        vidaAnterior = sistemaVidaJugador.vida;

        // Get the Rigidbody component and set it to kinematic to avoid physics interactions
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        // Move the ghost towards the player
        Vector3 direccion = (jugador.position - transform.position).normalized;
        rb.MovePosition(transform.position + direccion * velocidad * Time.deltaTime);

        // Rotate the ghost to face the player
        Quaternion rotacion = Quaternion.LookRotation(direccion);
        rb.MoveRotation(rotacion);

        // If the ghost is close enough to the player, deal damage
        if (Vector3.Distance(transform.position, jugador.position) <= distanciaAtaque)
        {
            // Reduce player's health without pushing them
            sistemaVidaJugador.vida -= daño * Time.deltaTime;

            // Update the health bar if the player's health changed
            if (sistemaVidaJugador.vida != vidaAnterior)
            {
                sistemaVidaJugador.ActualizarBarraVida();
                vidaAnterior = sistemaVidaJugador.vida;
            }
        }
    }
}

