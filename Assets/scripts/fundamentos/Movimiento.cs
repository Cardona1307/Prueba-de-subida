using UnityEngine;
using System.Collections;

public class movimiento : MonoBehaviour
{
    public float velocidad = 7f;
    public float fuerzaSalto = 7f;
    private Rigidbody rb;
    public Transform camara;
    public Vector3 offsetCamara = new Vector3(0f, 0.5f, 1.5f); // Offset para la posición de la cámara
    private bool puedeSaltar = true;
    public bool salta = false;
    public float velocidadSprint = 10f;
    private bool puedeSprintar = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Ajustar la posición inicial de la cámara
        if (camara != null)
        {
            camara.position = transform.position + offsetCamara;
            camara.parent = transform; // Hacer que la cámara sea hija del personaje
        }

        // Bloquear el cursor y hacerlo invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Control de movimiento y rotación horizontal del jugador
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        float movimientoVertical = Input.GetAxisRaw("Vertical");

        // Control de sprint
        if (Input.GetKey(KeyCode.LeftShift) && puedeSprintar)
        {
            velocidad = velocidadSprint;
        }
        else
        {
            velocidad = 7f; // Si no se está presionando la tecla de sprint, volver a la velocidad normal
        }

        // Control de rotación horizontal del jugador por el mouse
        transform.Rotate(0f, Input.GetAxis("Mouse X") * velocidad * Time.deltaTime, 0f);

        // Control de la rotación del modelo del jugador para que siga la rotación horizontal de la cámara
        if (camara != null)
        {
            Vector3 eulerAngles = camara.rotation.eulerAngles;
            eulerAngles.x = 0f;
            eulerAngles.z = 0f;
            Quaternion targetRotation = Quaternion.Euler(eulerAngles);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.15f);
        }

        // Control del movimiento del jugador
        Vector3 direccionMovimiento = camara.forward * movimientoVertical + camara.right * movimientoHorizontal;
        direccionMovimiento.y = 0f; // Aseguramos que el movimiento sea horizontal
        transform.position += direccionMovimiento.normalized * velocidad * Time.deltaTime;

        // Control de salto
        if (Input.GetButtonDown("Jump") && puedeSaltar)
        {
            if (!salta)
            {
                rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
                puedeSaltar = false;
                StartCoroutine(EsperarSegundos(1));
                salta = true;
            }
        }
    }

    private void saltando()
    {
        salta = false;
    }

    private IEnumerator EsperarSegundos(int segundos)
    {
        yield return new WaitForSeconds(segundos);
        puedeSaltar = true;
        saltando();
    }

    private IEnumerator Sprint()
    {
        yield return new WaitForSeconds(2);
        velocidad = 7f;
        yield return new WaitForSeconds(30);
        puedeSprintar = true;
    }
}
