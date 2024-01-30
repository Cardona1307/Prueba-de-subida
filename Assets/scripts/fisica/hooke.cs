using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hooke : MonoBehaviour
{
    //crear variables publicas para editar desde el inspector
    public float constanteElastica = 10f;
    public float amortiguamiento = 0.5f;

    //creamos variables privadads para realizar calculos internos

    private float velocidadObjeto;
    private float posicionObjeto;


    void Update()
    {
        SimularMovimiento();

    }

    void SimularMovimiento()
    {

        //Aplicar la fuerza elastica de acuerdo a la ley de hooke

        float fuerzaElastica = -constanteElastica * posicionObjeto;

        //Aplicar amortiguamiento para evitar osilaciones
        fuerzaElastica -= amortiguamiento * velocidadObjeto;
        float aceleracion = fuerzaElastica;

        //Actualizar la velocidad y la posicion usando lo siguiente
        velocidadObjeto += aceleracion * Time.deltaTime;
        posicionObjeto += velocidadObjeto * Time.deltaTime;

        //Ajustar la altura del objeto respecto de la posicion

        transform.position = new Vector3(transform.position.x, posicionObjeto, transform.position.z);
    }






}

