using UnityEngine;

public class quedarseArribaPlataforma : MonoBehaviour
{
    private GameObject plataforma; // La plataforma en la que el personaje está actualmente

    void OnCollisionEnter(Collision collision)
    {
        // Comprueba si el personaje ha colisionado con la plataforma
        if (collision.gameObject.name == "plataforma")
        {
            // Guarda una referencia a la plataforma
            plataforma = collision.gameObject;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Comprueba si el personaje ha dejado de colisionar con la plataforma
        if (collision.gameObject.name == "plataforma")
        {
            // Borra la referencia a la plataforma
            plataforma = null;
        }
    }

    void Update()
    {
        // Si el personaje está en la plataforma, mueve al personaje junto con la plataforma
        if (plataforma != null)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, plataforma.transform.position.z);
        }
    }
}
