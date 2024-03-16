using UnityEngine;
using UnityEngine.UI;

public class ControlPausa : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    void Update()
    {
        // Maneja la pausa/reanudación del juego al presionar Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ReanudarJuego();
            else
                PausarJuego();
        }
    }

    void PausarJuego()
    {
        // Pausa el tiempo y muestra el menú de pausa
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor
        Cursor.visible = true; // Hace visible el cursor
        isPaused = true;
    }

    public void ReanudarJuego()
    {
        // Reanuda el tiempo y oculta el menú de pausa
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor nuevamente
        Cursor.visible = false; // Oculta el cursor
        isPaused = false;
    }
}
