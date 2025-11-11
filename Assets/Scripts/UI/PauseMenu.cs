using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenuController : MonoBehaviour
{
    public GameObject container;

    public static PauseMenuController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Paus();
        }
    }

    public void Paus()
    {
        container.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    public void ResumeBtn()
    {
        container.SetActive(false);
        Time.timeScale = 1; // Resume the game
    }

    public void MainMenuBtn()
    {
        // Load the main menu scene (assuming it's named "MainMenu")
        SceneController.instance.ToMainMenu();
        Time.timeScale = 1; // Ensure time scale is reset when loading a new scene
    }
}