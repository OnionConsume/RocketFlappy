using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Deze class regelt de globale game logica (game over, restart, etc.)
public class GameManager : MonoBehaviour
{
    // Static instance zodat andere scripts makkelijk bij de GameManager kunnen
    // Bijvoorbeeld: GameManager.instance.GameOver();
    public static GameManager instance;

    // Dit is het Game Over scherm (Canvas)
    // Die zetten we aan als de speler verliest
    [SerializeField] private GameObject _gameOverCanvas;

    private void Awake()
    {
        // Singleton check
        // Zorgt ervoor dat er maar 1 GameManager bestaat
        if (instance == null)
        {
            instance = this;
        }

        // Zorgt ervoor dat het spel normaal loopt bij het starten
        // Handig als je de scene herstart na een game over
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        // Zet het game over scherm aan
        _gameOverCanvas.SetActive(true);

        // Zet de tijd stil zodat alles stopt (pijpen, zwaartekracht, etc.)
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // Laadt de huidige scene opnieuw
        // Makkelijker dan alles handmatig resetten
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}