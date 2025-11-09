using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{

    //public GameObject loadingScreen;

    //public int sceneID = 3;


    //private void Start()
    //{
    //    StartCoroutine(LoadSceneAsync(sceneID));
    //}

    //public void LoadScene(int sceneID)
    //{

    //}

    void Update()
    {
        // Cek apakah tombol SPACE ditekan
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // Pindah ke scene GameScene
            SceneManager.LoadScene("GameScene");
            Time.timeScale = 1; // Ensure time scale is reset when loading a new scene
        }
    }

    //IEnumerator LoadSceneAsync(int sceneID)
    //{
    //    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
    //    loadingScreen.SetActive(true);
    //    while (!operation.isDone)
    //    {
    //        yield return null;
    //    }
    //    loadingScreen.SetActive(false);
    //}

    public void ExitGame()
    {
        Debug.Log("Exitting game...");
        Application.Quit();
    }
}
