using UnityEngine;

public class Boost : PickUpAbles
{
    protected override void action(Player player)
    {
        player.updateBooster(100f);
    }
}