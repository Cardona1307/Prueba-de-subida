using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rebote : MonoBehaviour
{
    public float fuerzaImpulso = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona tiene un Rigidbody
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Aplicar impulso en la dirección hacia arriba
            rb.AddForce(Vector3.up * fuerzaImpulso, ForceMode.Impulse);
        }
    }
}