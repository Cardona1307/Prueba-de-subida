using UnityEngine;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Button resumeButton; // Asegúrate de asignar este botón en el Inspector de Unity

    private void Start()
    {
        // Configura el botón de reanudar para llamar a la función ResumeGame cuando se haga clic en él
        resumeButton.onClick.AddListener(ResumeGame);
    }

    void Update()
    {
        HandlePauseMenu();
    }

    void HandlePauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
    }
}
