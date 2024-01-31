using UnityEngine;

public class mov_plataforma : MonoBehaviour
{
    public float zMin = 40; // Posici�n m�nima en el eje Z
    public float zMax = 65; // Posici�n m�xima en el eje Z
    public float speed = 1f; // Velocidad de movimiento
    private int direction = 1; // Direcci�n del movimiento

    void Update()
    {
        // Calcula la nueva posici�n
        float zNew = transform.position.z + direction * speed * Time.deltaTime;

        // Comprueba si la plataforma ha alcanzado un l�mite
        if (zNew < zMin)
        {
            zNew = zMin;
            direction = 1; // Cambia la direcci�n del movimiento
        }
        else if (zNew > zMax)
        {
            zNew = zMax;
            direction = -1; 
        }

        // Mueve la plataforma a la nueva posici�n
        transform.position = new Vector3(transform.position.x, transform.position.y, zNew);
    }
}
