using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;
    public float altura = 10.0f; // Altura adicional en el eje Y en tercera persona
    public float alturaPrimeraPersona = 20.0f; // Altura adicional en el eje Y en primera persona
    public float campoDeVisionPrimeraPersona = 90.0f; // Campo de visi�n en primera persona
    private bool primeraPersona = false; // Controla si la c�mara est� en modo de primera persona

    private float x = 0.0f;
    private float y = 0.0f;

    // Variables para controlar el zoom de la c�mara
    private float distance = 50.0f; // Distancia inicial de la c�mara
    private float minDistance = 2.0f; // Distancia m�nima permitida
    private float maxDistance = 8.0f; // Distancia m�xima permitida
    private float scrollSpeed = 7.0f; // Velocidad del zoom

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void Update()
    {
        // Cambia el modo de la c�mara cuando se presiona la tecla "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            primeraPersona = !primeraPersona;
            GetComponent<Camera>().fieldOfView = primeraPersona ? campoDeVisionPrimeraPersona : 60.0f; // Ajusta el campo de visi�n
        }

        // Controla el zoom de la c�mara con el scroll del mouse
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
                // En modo de primera persona, la c�mara est� en la misma posici�n que el objetivo pero m�s arriba
                position = target.position + new Vector3(0, alturaPrimeraPersona, 0);
            }
            else
            {
                // En modo de tercera persona, la c�mara est� detr�s y por encima del objetivo
                position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position + new Vector3(0, altura, 0);
            }

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
