using UnityEngine;

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
        HUDManager.instance.UpdateCoinCounter(currCoinAmmount);
    }

    public void triggerGameOver()
    {
        HUDManager.instance.ShowGameOverScreen(currCoinAmmount, distance);
    }

    public void triggerWin(string title = "You Win!")
    {
        HUDManager.instance.ShowGameOverScreen(currCoinAmmount, distance, title, true);
    }

    public void resetGameData()
    {
        currCoinAmmount = 0;
        distance = 0;
        HUDManager.instance.UpdateCoinCounter(currCoinAmmount);
        HUDManager.instance.UpdateDistanceCounter(distance);
    }
}
