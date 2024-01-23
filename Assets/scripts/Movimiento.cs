using UnityEngine;
using System.Collections;

public class movimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;
    public Transform camara; // Referencia a la cámara
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

        // Calcula la dirección de movimiento basada en la rotación de la cámara
        Vector3 direccion = (camara.forward * movimientoVertical + camara.right * movimientoHorizontal).normalized;
        direccion.y = 0f; // Ignora la rotación de la cámara alrededor del eje X

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
