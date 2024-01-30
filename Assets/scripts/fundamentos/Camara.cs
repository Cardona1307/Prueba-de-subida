using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;
    public float altura = 10.0f; // Altura adicional en el eje Y en tercera persona
    public float alturaPrimeraPersona = 20.0f; // Altura adicional en el eje Y en primera persona
    public float campoDeVisionPrimeraPersona = 90.0f; // Campo de visión en primera persona
    private bool primeraPersona = false; // Controla si la cámara está en modo de primera persona

    private float x = 0.0f;
    private float y = 0.0f;

    // Variables para controlar el zoom de la cámara
    private float distance = 50.0f; // Distancia inicial de la cámara
    private float minDistance = 2.0f; // Distancia mínima permitida
    private float maxDistance = 8.0f; // Distancia máxima permitida
    private float scrollSpeed = 7.0f; // Velocidad del zoom

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void Update()
    {
        // Cambia el modo de la cámara cuando se presiona la tecla "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            primeraPersona = !primeraPersona;
            GetComponent<Camera>().fieldOfView = primeraPersona ? campoDeVisionPrimeraPersona : 60.0f; // Ajusta el campo de visión
        }

        // Controla el zoom de la cámara con el scroll del mouse
        if (!primeraPersona)
        {
            distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
        }
    }

    void LateUpdate()
    {
        if (target)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position;

            if (primeraPersona)
            {
                // En modo de primera persona, la cámara está en la misma posición que el objetivo pero más arriba
                position = target.position + new Vector3(0, alturaPrimeraPersona, 0);
            }
            else
            {
                // En modo de tercera persona, la cámara está detrás y por encima del objetivo
                position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position + new Vector3(0, altura, 0);
            }

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
