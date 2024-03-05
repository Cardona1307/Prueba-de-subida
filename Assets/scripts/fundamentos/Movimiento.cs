using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class movimiento : MonoBehaviour
{
    public float velocidadNormal = 7f; // Velocidad base
    public float velocidadSprint = 10f; // Velocidad de sprint
    public float tiempoSprint = 5f; // Tiempo en segundos que dura el sprint
    public float tiempoRecarga = 30f; // Tiempo en segundos de recarga del sprint
    private bool puedeSprintar = true;
    private bool sprintActivo = false;

    private Rigidbody rb;
    public Transform camara;
    public Vector3 offsetCamara = new Vector3(0f, 0.5f, 1.5f); // Offset para la posición de la cámara
    private bool puedeSaltar = true;
    public float fuerzaSalto = 7f;

    // Referencia a la barra de sprint
    public Image BarraSprint;

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
        if (Input.GetKeyDown(KeyCode.LeftShift) && puedeSprintar)
        {
            StartCoroutine(Sprint());
        }

        // Control de rotación horizontal del jugador por el mouse
        transform.Rotate(0f, Input.GetAxis("Mouse X") * velocidadNormal * Time.deltaTime, 0f);

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

        if (sprintActivo) // Si el sprint está activo, usar la velocidad de sprint
        {
            transform.position += direccionMovimiento.normalized * velocidadSprint * Time.deltaTime;
        }
        else // Si no, usar la velocidad normal
        {
            transform.position += direccionMovimiento.normalized * velocidadNormal * Time.deltaTime;
        }

        // Control de salto
        if (Input.GetButtonDown("Jump") && puedeSaltar)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            puedeSaltar = false;
            StartCoroutine(RecargarSalto(tiempoRecarga));
        }

        // Actualizar la barra de sprint
        if (sprintActivo)
        {
            BarraSprint.fillAmount -= 1f / tiempoSprint * Time.deltaTime;
            if (BarraSprint.fillAmount <= 0)
            {
                sprintActivo = false;
                StartCoroutine(RecargarSprint(tiempoRecarga));
            }
        }
        else if (!puedeSprintar)
        {
            BarraSprint.fillAmount += 1f / tiempoRecarga * Time.deltaTime;
        }
    }

    private IEnumerator RecargarSalto(float tiempoRecarga)
    {
        yield return new WaitForSeconds(tiempoRecarga);
        puedeSaltar = true;
    }

    private IEnumerator Sprint()
    {
        sprintActivo = true;
        puedeSprintar = false;
        yield return new WaitForSeconds(tiempoSprint);
        sprintActivo = false;
        StartCoroutine(RecargarSprint(tiempoRecarga));
    }

    private IEnumerator RecargarSprint(float tiempoRecarga)
    {
        yield return new WaitForSeconds(tiempoRecarga);
        puedeSprintar = true;
    }
}
