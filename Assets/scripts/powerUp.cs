using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public Transform centroDeMasa;
    public float velocidadOrbita = 10f;
    public string destroyableTag = "destruir"; // Etiqueta del objeto que se puede destruir
    public float destructionRange = 1f; // Rango en el que el objeto será destruido
    public string playerTag = "player"; // Etiqueta del jugador
    private bool isPickedUp = false; // Indica si el power-up ha sido recogido

    void Update()
    {
        if (isPickedUp)
        {
            orbita();
            destruirObjetoCercano();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag)) // Si el jugador pasa por encima del power-up
        {
            isPickedUp = true; // El power-up ha sido recogido
            centroDeMasa = other.transform; // El centro de masa ahora es el jugador
            transform.localPosition = new Vector3(0, 0, 0); // La esfera orbitará más cerca del jugador
        }
    }

    void orbita()
    {
        transform.RotateAround(centroDeMasa.position, Vector3.up, velocidadOrbita * Time.deltaTime);
    }

    void destruirObjetoCercano()
    {
        // Busca todos los objetos con la etiqueta "Destroyable" dentro del rango de destrucción
        Collider[] objectsInRange = Physics.OverlapSphere(transform.position, destructionRange);
        foreach (Collider col in objectsInRange)
        {
            if (col.CompareTag(destroyableTag))
            {
                Destroy(col.gameObject); // Destruye el objeto
            }
        }
    }
}



