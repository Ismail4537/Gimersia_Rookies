using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject container;

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            // Toggle pause menu
            if (container.activeSelf)
            {
                // Jika pause menu sedang aktif, tutup pause menu
                ResumeGame();
            }
            else
            {
                // Jika pause menu tidak aktif, buka pause menu
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        container.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    private void ResumeGame()
    {
        container.SetActive(false);
        Time.timeScale = 1; // Resume the game
    }

    public void ResumeBtn()
    {
        ResumeGame();
    }

    public void MainMenuBtn(int sceneID)
    {
        // Load the main menu scene
        SceneManager.LoadScene(sceneID);
        Time.timeScale = 1; // Ensure time scale is reset when loading a new scene
    }

    public void RetryGame()
    {
        // Lanjutkan waktu game
        Time.timeScale = 1f;

        // Muat ulang scene saat ini
        SceneManager.LoadScene(1);
    }
}