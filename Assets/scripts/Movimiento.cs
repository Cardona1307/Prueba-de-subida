using UnityEngine;
using System.Collections;

public class movimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;
    public Transform camara; // Referencia a la c�mara
    private Rigidbody rb;
    private bool puedeSaltar = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        float movimientoVertical = Input.GetAxisRaw("Vertical");

        // Calcula la direcci�n de movimiento basada en la rotaci�n de la c�mara
        Vector3 direccion = (camara.forward * movimientoVertical + camara.right * movimientoHorizontal).normalized;
        direccion.y = 0f; // Ignora la rotaci�n de la c�mara alrededor del eje X

        rb.velocity = new Vector3(direccion.x * velocidad, rb.velocity.y, direccion.z * velocidad);

        if (Input.GetButtonDown("Jump") && puedeSaltar)
        {
            rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            puedeSaltar = false;
            StartCoroutine(EsperarSegundos(1));
        }
    }

    IEnumerator EsperarSegundos(int segundos)
    {
        yield return new WaitForSeconds(segundos);
        puedeSaltar = true;
    }
}
