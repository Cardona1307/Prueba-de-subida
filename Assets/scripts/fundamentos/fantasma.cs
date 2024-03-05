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
    private Light luzJugador; // Referencia a la luz del jugador

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform;
        sistemaVidaJugador = jugador.GetComponent<SistemaVida>();
        vidaAnterior = sistemaVidaJugador.vida;
        luzJugador = GetComponentInChildren<Light>(); // Busca la luz como un hijo del objeto fantasma
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        luzJugador = GameObject.FindGameObjectWithTag("Linterna").GetComponent<Light>(); // Asigna la luz del jugador
    }

    void Update()
    {
        if (luzJugador.enabled && Vector3.Distance(transform.position, luzJugador.transform.position) <= luzJugador.range)
        {
            Escapar();
        }
        else
        {
            PerseguirJugador();
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
    }

    void Escapar()
    {
        Vector3 direccionEscape = -(jugador.position - transform.position).normalized;
        rb.MovePosition(transform.position + direccionEscape * velocidadEscape * Time.deltaTime);
        Quaternion rotacionEscape = Quaternion.LookRotation(direccionEscape);
        rb.MoveRotation(rotacionEscape);
    }
}
