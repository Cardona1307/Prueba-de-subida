using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ControlEscenas : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        UnityEngine.Debug.Log("Salir del juego");
        Application.Quit();
    }

    public void Opciones()
    {
        SceneManager.LoadScene(2);
    }

    public void SalirMenú()
    {
        SceneManager.LoadScene(0);
    }
}