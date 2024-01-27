using UnityEngine;

public class fantasma : MonoBehaviour
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
        // Encuentra al jugador en la escena usando la etiqueta y obtén el componente SistemaVida
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform;
        sistemaVidaJugador = jugador.GetComponent<SistemaVida>();
        vidaAnterior = sistemaVidaJugador.vida;

        // Obtén el componente Rigidbody y configúralo para ignorar la física
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

        // Si el fantasma está lo suficientemente cerca del jugador, haz daño
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
}
