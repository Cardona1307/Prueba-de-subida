using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubeVida : MonoBehaviour
{
    SistemaVida vidaPlayer;

    public int cantidad;
    public float damageTime;
    float currentDamageTime;

    void Start()
    {
        vidaPlayer = GameObject.FindWithTag("Jugador").GetComponent<SistemaVida>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                vidaPlayer.vida += cantidad;
                // Comprueba si la vida del jugador ha alcanzado el máximo
                if (vidaPlayer.vida >= 100)
                {
                    // Destruye este objeto
                    Destroy(gameObject);
                }

                currentDamageTime = 0.0f;

                // Comprueba si la vida del jugador ha alcanzado el máximo
                if (vidaPlayer.vida >= 100)
                {
                    // Destruye este objeto
                    Destroy(gameObject);
                }
            }
        }
    }
}
