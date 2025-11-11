using UnityEngine;

public class Coin : PickUpAbles
{
    protected override void action(Player player)
    {
        SFXManager.instance.PlayClip3D("Coin", transform.position, 1.0f);
        GameManager.instance.UpdateCurrCoinAmmount(1);
    }
}