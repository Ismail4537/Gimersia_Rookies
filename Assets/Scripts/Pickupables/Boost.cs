using UnityEngine;

public class Boost : PickUpAbles
{
    protected override void action(Player player)
    {
        SFXManager.instance.PlayClip3D("GetBooster", transform.position, 1.0f);
        player.updateBooster(100f);
    }
}