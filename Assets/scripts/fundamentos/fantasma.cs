using System.Collections;
using UnityEngine;

public class Fantasma : MonoBehaviour
{
    public float velocidadPersecucion = 5f;
    public float velocidadEscape = 10f;
    public float distanciaAtaque = 1f;
    public float daño = 1f;
    private Transform jugador;
    private SistemaVida sistemaVidaJugador;
    private Rigidbody rb;
    private float vidaAnterior;
    private bool esPerseguido = true;
    private float tiempoEscapando = 0f;
    private float tiempoEscapandoLimite = 3f; // Tiempo límite para escapar en segundos

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform;
        sistemaVidaJugador = jugador.GetComponent<SistemaVida>();
        vidaAnterior = sistemaVidaJugador.vida;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if (esPerseguido)
        {
            PerseguirJugador();
        }
        else
        {
            Escapar();
            tiempoEscapando += Time.deltaTime;
            if (tiempoEscapando >= tiempoEscapandoLimite)
            {
                tiempoEscapando = 0f;
                esPerseguido = true; // Vuelve a perseguir al jugador
            }
        }
    }

    void PerseguirJugador()
    {
        Vector3 direccion = (jugador.position - transform.position).normalized;
        rb.MovePosition(transform.position + direccion * velocidadPersecucion * Time.deltaTime);
        Quaternion rotacion = Quaternion.LookRotation(direccion);
        rb.MoveRotation(rotacion);

        if (Vector3.Distance(transform.position, jugador.position) <= distanciaAtaque)
        {
            sistemaVidaJugador.vida -= daño * Time.deltaTime;
            if (sistemaVidaJugador.vida != vidaAnterior)
            {
                sistemaVidaJugador.ActualizarBarraVida();
                vidaAnterior = sistemaVidaJugador.vida;
            }
        }

        // Comprobar si la luz del jugador alcanza al fantasma
        GameObject jugadorObjeto = GameObject.FindGameObjectWithTag("Jugador");
        if (jugadorObjeto != null)
        {
            Light luzJugador = jugadorObjeto.GetComponentInChildren<Light>();
            if (luzJugador != null && luzJugador.enabled && Vector3.Distance(transform.position, luzJugador.transform.position) <= luzJugador.range)
            {
                esPerseguido = false;
            }
        }
    }

    void Escapar()
    {
        Vector3 direccionEscape = -(jugador.position - transform.position).normalized;
        rb.MovePosition(transform.position + direccionEscape * velocidadEscape * Time.deltaTime);
        Quaternion rotacionEscape = Quaternion.LookRotation(direccionEscape);
        rb.MoveRotation(rotacionEscape);
    }
}
