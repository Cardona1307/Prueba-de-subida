using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    public float fuerzaSalto = 10f;
    private Rigidbody rb; // Referencia al Rigidbody

    void Start()
    {
        // Obtiene la referencia al Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = Vector3.up * fuerzaSalto;
        }
    }

    // Verifica si el personaje está en el suelo
    bool IsGrounded()
    {
        float distanceToGround = GetComponent<Collider>().bounds.extents.y;
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }
}
