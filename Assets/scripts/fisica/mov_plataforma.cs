using UnityEngine;

public class mov_plataforma : MonoBehaviour
{
    public float zMin = 40; // Posición mínima en el eje Z
    public float zMax = 65; // Posición máxima en el eje Z
    public float speed = 1f; // Velocidad de movimiento
    private int direction = 1; // Dirección del movimiento

    void Update()
    {
        // Calcula la nueva posición
        float zNew = transform.position.z + direction * speed * Time.deltaTime;

        // Comprueba si la plataforma ha alcanzado un límite
        if (zNew < zMin)
        {
            zNew = zMin;
            direction = 1; // Cambia la dirección del movimiento
        }
        else if (zNew > zMax)
        {
            zNew = zMax;
            direction = -1; 
        }

        // Mueve la plataforma a la nueva posición
        transform.position = new Vector3(transform.position.x, transform.position.y, zNew);
    }
}
