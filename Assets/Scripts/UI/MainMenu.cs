using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject container;
    //public GameObject creditContainer;

    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
        Time.timeScale = 1;
    }

    public void settingsBtn()
    {
        container.SetActive(true);
        Time.timeScale = 0;
    }

    public void creditBtn()
    {
        container.SetActive(true);
        Time.timeScale = 0;
    }

    public void closeBtn()
    {
        container.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("Quit game...");
        Application.Quit();
    }
}