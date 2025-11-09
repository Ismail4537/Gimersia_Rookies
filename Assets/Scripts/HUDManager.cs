using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;
    public int currCoinAmmount = 0;
    [SerializeField] Slider boosterMeter;
    [SerializeField] TextMeshProUGUI coinCounter;
    [SerializeField] TextMeshProUGUI distanceCounter;
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
        currCoinAmmount += amount;
        UpdateCoinCounter(currCoinAmmount);
    }

    public void UpdateCoinCounter(int amount)
    {
        coinCounter.text = amount.ToString();
    }

    public void UpdateDistanceCounter(float distance)
    {
        distanceCounter.text = distance.ToString("F2") + "m";
    }
}
