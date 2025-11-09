using UnityEngine;

public class Coin : PickUpAbles
{
    protected override void action(Player player)
    {
        HUDManager.instance.UpdateCurrCoinAmmount(1);
        Debug.Log("Coin Collected");
    }
}