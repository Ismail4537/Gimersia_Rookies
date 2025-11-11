using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager instance;
    [SerializeField] GameObject HUD;
    [SerializeField] Slider boosterMeter;
    [SerializeField] TextMeshProUGUI coinCounter;
    [SerializeField] TextMeshProUGUI distanceCounter;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI finalCoinText;
    [SerializeField] TextMeshProUGUI finalDistanceText;
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] Button nextStageButton;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        toggleHUD(true);
    }

    public void UpdateBoosterMeter(float amount)
    {
        boosterMeter.value = amount;
    }

    public void UpdateCoinCounter(int amount)
    {
        coinCounter.text = amount.ToString();
    }

    public void UpdateDistanceCounter(float distance)
    {
        GameManager.instance.distance = distance;
        distanceCounter.text = distance.ToString("F2") + "m";
    }

    public void toggleHUD(bool isActive)
    {
        HUD.SetActive(isActive);
    }

    public void ShowGameOverScreen(int finalScore, float finalDistance, string title = "Game Over", bool isWin = false)
    {
        finalCoinText.text = finalScore.ToString();
        finalDistanceText.text = finalDistance.ToString("F2") + "m";
        titleText.text = title;
        toggleHUD(false);

        if (isWin)
        {
            nextStageButton.gameObject.SetActive(true);
        }
        else
        {
            nextStageButton.gameObject.SetActive(false);
        }

        gameOverScreen.SetActive(true);
    }

    public void RestartBtn()
    {
        gameOverScreen.SetActive(false);
        SceneController.instance.RestartScene();
    }

    public void MainMenuBtn()
    {
        gameOverScreen.SetActive(false);
        SceneController.instance.ToMainMenu();
    }

    public void NextStageBtn()
    {
        gameOverScreen.SetActive(false);
        SceneController.instance.ToNextScene();
    }
}
