using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target;
    public float alturaPrimeraPersona = 2.0f;

    private float x = 0.0f;
    private float y = 0.0f;

    void LateUpdate()
    {
        if (target)
        {
            // Rotación de la cámara controlada por el ratón
            x += Input.GetAxis("Mouse X");
            y -= Input.GetAxis("Mouse Y");

            // Clamp vertical rotation to avoid flipping the camera upside down
            y = Mathf.Clamp(y, -89f, 89f);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 posicion = target.position + new Vector3(0, alturaPrimeraPersona, 0);

            // Aplicar rotación y posición a la cámara
            transform.rotation = rotation;
            transform.position = posicion;
        }
    }
}
