using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacionMonedas : MonoBehaviour
{
    public float velocidadRotacion = 30.0f;

    private void Update()
    {
        float rotacionX = velocidadRotacion * Time.deltaTime;
        transform.Rotate(Vector3.right * rotacionX);
    }
}
