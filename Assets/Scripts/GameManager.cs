using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int currCoinAmmount = 0;
    public float distance = 0;
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
    }

    public void UpdateCurrCoinAmmount(int amount)
    {
        currCoinAmmount += amount;
        GameUIManager.instance.UpdateCoinCounter(currCoinAmmount);
    }

    public void triggerGameOver()
    {
        if (GameUIManager.instance.isGameOverScreenActive())
            return;
        saveCurrStageData();
        SFXManager.instance.PlayClip2D("GameOver", 1.0f);
        GameUIManager.instance.ShowGameOverScreen(currCoinAmmount, distance);
    }

    public void triggerWin(string title = "Score")
    {
        if (GameUIManager.instance.isGameOverScreenActive())
            return;
        saveCurrStageData();
        SFXManager.instance.PlayClip2D("GetBooster", 1.0f);
        PlayerPrefs.SetString("Stage_" + SceneManager.GetActiveScene().buildIndex + "_Win", "Yes");
        GameUIManager.instance.ShowGameOverScreen(currCoinAmmount, distance, title, true);
    }

    public void resetGameData()
    {
        currCoinAmmount = 0;
        distance = 0;
        GameUIManager.instance.UpdateCoinCounter(currCoinAmmount);
        GameUIManager.instance.UpdateDistanceCounter(distance);
    }

    public void saveCurrStageData()
    {
        string stageKey = "Stage_" + SceneManager.GetActiveScene().buildIndex;
        int savedCoin = PlayerPrefs.GetInt(stageKey + "_Coin", 0);
        float savedDistance = PlayerPrefs.GetFloat(stageKey + "_Distance", 0);
        if (currCoinAmmount > savedCoin)
        {
            PlayerPrefs.SetInt(stageKey + "_Coin", currCoinAmmount);
        }
        if (distance > savedDistance)
        {
            PlayerPrefs.SetFloat(stageKey + "_Distance", distance);
        }
    }
}
