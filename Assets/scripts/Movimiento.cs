using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float velocidadr = 200f;
    public float fuerzaSalto = 7f; // Fuerza del salto
    private Rigidbody rb; // Referencia al Rigidbody
    public Transform camara; // Referencia a la c�mara
    private Animator anim;
    private bool puedeSaltar = true;
    public bool salta = false;

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

        transform.Translate(0, 0, y * Time.deltaTime * velocidad);
        transform.Rotate(0, x * Time.deltaTime * velocidadr, 0);

        anim.SetFloat("velocidadY", y);
        anim.SetFloat("velocidadX", x);

        // Calcula la direcci�n de movimiento basada en la rotaci�n de la c�mara
        //Vector3 direccion = (camara.forward * y + camara.right * x).normalized;
        //direccion.y = 0f; // Ignora la rotaci�n de la c�mara alrededor del eje X

        //rb.velocity = new Vector3(direccion.x * velocidad, rb.velocity.y, direccion.z * velocidad);

        if ((Input.GetButtonDown("Jump")) && puedeSaltar )
        {
            if (salta == false)
            {
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                puedeSaltar = false;
                 StartCoroutine(EsperarSegundos(1));
                anim.SetTrigger("jump");
                salta = true;


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
    }
    }
}
    