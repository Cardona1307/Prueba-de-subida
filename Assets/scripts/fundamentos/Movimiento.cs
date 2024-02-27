using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidad = 7f;
    public float velocidadRotacion = 400f;
    public float fuerzaSalto = 7f; // Fuerza del salto
    private Rigidbody rb; // Referencia al Rigidbody
    public Transform camara; // Referencia a la cámara
    private Animator anim;
    private bool puedeSaltar = true;
    public bool salta = false;
    public float velocidadSprint = 10f; // Velocidad del sprint
    private bool puedeSprintar = true; // Controla si el sprint está disponible

    void Start()
    {
        // Obtiene la referencia al Rigidbody
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento horizontal y vertical con WASD
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Comprueba si el jugador ha presionado la tecla "shift" y si el sprint está disponible
        if (Input.GetKey(KeyCode.LeftShift) && puedeSprintar)
        {
            velocidad = velocidadSprint; // Aumenta la velocidad
            puedeSprintar = false; // Desactiva el sprint
            StartCoroutine(Sprint());
        }

        transform.Translate(0, 0, y * Time.deltaTime * velocidad);
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);

        anim.SetFloat("velocidadY", y);
        anim.SetFloat("velocidadX", x);

        if ((Input.GetButtonDown("Jump")) && puedeSaltar)
        {
            if (salta == false)
            {
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                puedeSaltar = false;
                StartCoroutine(EsperarSegundos(1));

                salta = true;
            }
        }
    }

    void saltando()
    {
        salta = false;
    }

    IEnumerator EsperarSegundos(int segundos)
    {
        yield return new WaitForSeconds(segundos);
        puedeSaltar = true;
        saltando();
    }

    IEnumerator Sprint()
    {
        yield return new WaitForSeconds(5); // Espera 5 segundos
        velocidad = 7f; // Restaura la velocidad
        yield return new WaitForSeconds(55); // Espera 55 segundos adicionales
        puedeSprintar = true; // Reactiva el sprint
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            
            Animator anim = GetComponent<Animator>();
            anim.SetTrigger("GetHit");
        }
    }



}
