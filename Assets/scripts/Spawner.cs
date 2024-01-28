using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public GameObject ghost; // El prefab del fantasma
    public float tiempoSpawn = 10f; // El tiempo entre spawns
    public float rangoSpawn = 10f; // El rango en el que los fantasmas pueden spawnear
    private Transform jugador; // La posici�n del jugador

    void Start()
    {
        // Encuentra al jugador en la escena usando la etiqueta
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform;

        // Comienza la Coroutine para spawnear fantasmas
        StartCoroutine(SpawnFantasmas());
    }

    IEnumerator SpawnFantasmas()
    {
        // Espera el tiempo especificado antes de spawnear el primer fantasma
        yield return new WaitForSeconds(tiempoSpawn);

        while (true)
        {
            // Genera una posici�n aleatoria dentro del rango alrededor del jugador
            Vector3 posicionSpawn = jugador.position + UnityEngine.Random.insideUnitSphere * rangoSpawn;
            posicionSpawn.y = 0;

            // Crea un nuevo fantasma en la posici�n aleatoria
            Instantiate(ghost, posicionSpawn, Quaternion.identity);

            // Espera el tiempo especificado antes de spawnear otro fantasma
            yield return new WaitForSeconds(tiempoSpawn);
        }
    }
}
