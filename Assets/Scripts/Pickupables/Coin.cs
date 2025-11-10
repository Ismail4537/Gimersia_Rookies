using UnityEngine;

public class Coin : PickUpAbles
{
    protected override void action(Player player)
    {
        GameManager.instance.UpdateCurrCoinAmmount(1);
    }
}