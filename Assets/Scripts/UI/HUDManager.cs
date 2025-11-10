using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;
    [SerializeField] Slider boosterMeter;
    [SerializeField] TextMeshProUGUI coinCounter;
    [SerializeField] TextMeshProUGUI distanceCounter;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI finalScoreText;
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

    public void UpdateBoosterMeter(float amount)
    {
        boosterMeter.value = amount;
    }

    public void UpdateCurrCoinAmmount(int amount)
    {
        GameManager.instance.currCoinAmmount += amount;
        UpdateCoinCounter(GameManager.instance.currCoinAmmount);
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

    public void ShowGameOverScreen(int finalScore, float finalDistance, string title = "Game Over", bool isWin = false)
    {
        finalScoreText.text = finalScore.ToString();
        finalDistanceText.text = finalDistance.ToString("F2") + "m";
        titleText.text = title;

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
