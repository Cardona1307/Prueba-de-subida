using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public Transform camara; // Referencia a la cámara

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcula la dirección de movimiento basada en la rotación de la cámara
        Vector3 direccion = (camara.forward * movimientoVertical + camara.right * movimientoHorizontal).normalized;
        direccion.y = 0f; // Ignora la rotación de la cámara alrededor del eje X

        // Aplica la fuerza de movimiento
        GetComponent<Rigidbody>().AddForce(direccion * velocidad);
    }
}
