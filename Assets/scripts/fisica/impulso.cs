using UnityEngine;

public class impulso : MonoBehaviour
{
    public float impulsoFuerza = 10.0f; // La fuerza del impulso
    private Rigidbody rb; // El componente Rigidbody del personaje

    void Start()
    {
        // Obtiene el componente Rigidbody del personaje
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Comprueba si el personaje ha colisionado con la plataforma
        if (collision.gameObject.name == "impulso")
        {
            // Aplica un impulso en el eje X
            rb.AddForce(Vector3.left * impulsoFuerza, ForceMode.Impulse);
        }
    }
}
