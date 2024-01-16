using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public Transform camara; // Referencia a la c�mara

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcula la direcci�n de movimiento basada en la rotaci�n de la c�mara
        Vector3 direccion = (camara.forward * movimientoVertical + camara.right * movimientoHorizontal).normalized;
        direccion.y = 0f; // Ignora la rotaci�n de la c�mara alrededor del eje X

        // Aplica la fuerza de movimiento
        GetComponent<Rigidbody>().AddForce(direccion * velocidad);
    }
}
