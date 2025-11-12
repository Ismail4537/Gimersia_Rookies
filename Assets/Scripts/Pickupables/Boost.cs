using UnityEngine;

public class Boost : PickUpAbles
{
    public float amount = 50f;
    protected override void action(Player player)
    {
        SFXManager.instance.PlayClip3D("GetBooster", transform.position, 1.0f);
        player.updateBooster(amount);
    }
}