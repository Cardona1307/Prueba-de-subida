using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public float rayLength = 100f; // Longitud del rayo
    public string destroyableTag = "destruir"; // Etiqueta del objeto que se puede destruir
    private LineRenderer lineRenderer; // LineRenderer para visualizar el rayo

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>(); // Agrega un LineRenderer al jugador
        lineRenderer.startWidth = 0.05f; // Configura el ancho inicial del rayo
        lineRenderer.endWidth = 0.05f; // Configura el ancho final del rayo
        lineRenderer.enabled = false; // Desactiva el LineRenderer al inicio
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Cuando se presiona la tecla R
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength)) // Lanza un rayo hacia adelante
            {
                if (hit.transform.CompareTag(destroyableTag)) // Si el objeto golpeado tiene la etiqueta "Destroyable"
                {
                    Destroy(hit.transform.gameObject); // Destruye el objeto
                }

                // Visualiza el rayo
                lineRenderer.SetPosition(0, transform.position); // Configura la posición inicial del rayo
                lineRenderer.SetPosition(1, hit.point); // Configura la posición final del rayo
                lineRenderer.enabled = true; // Activa el LineRenderer
            }
        }
        else if (lineRenderer.enabled)
        {
            lineRenderer.enabled = false; // Desactiva el LineRenderer cuando se suelta la tecla R
        }
    }
}
