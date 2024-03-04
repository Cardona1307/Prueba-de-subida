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
            // Rotaci�n de la c�mara controlada por el rat�n
            x += Input.GetAxis("Mouse X");
            y -= Input.GetAxis("Mouse Y");

            // Clamp vertical rotation to avoid flipping the camera upside down
            y = Mathf.Clamp(y, -89f, 89f);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 posicion = target.position + new Vector3(0, alturaPrimeraPersona, 0);

            // Aplicar rotaci�n y posici�n a la c�mara
            transform.rotation = rotation;
            transform.position = posicion;
        }
    }
}
