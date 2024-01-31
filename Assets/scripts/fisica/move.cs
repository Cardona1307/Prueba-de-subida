using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 2f;
    public Transform cam;
    private bool isOnIce = false; // Indica si el personaje está sobre hielo

    private Rigidbody rb;
    private Vector3 movement;
    private Vector3 camForward;
    private Vector3 camRight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Movimiento basado en la dirección de la cámara
        camForward = cam.forward;
        camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        movement = horizontalInput * camRight + verticalInput * camForward;

        if (isOnIce)
        {
            // Si el personaje está sobre hielo, duplica la velocidad de movimiento
            movement *= 2;
        }

        // Salto
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Aplica el movimiento
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Comprueba si el personaje ha colisionado con la plataforma de hielo
        if (collision.gameObject.name == "plat_hielo")
        {
            isOnIce = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Comprueba si el personaje ha dejado de colisionar con la plataforma de hielo
        if (collision.gameObject.name == "plat_hielo")
        {
            isOnIce = false;
        }
    }
}
