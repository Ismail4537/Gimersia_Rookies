using UnityEngine;

public class BoardCheck : CollideChecker
{
    protected override void enterCondition()
    {
        if (player.transform.eulerAngles.z <= 300 && player.transform.eulerAngles.z >= 60 && !player.isGrounded)
        {
            SFXManager.instance.PlayClip3D("test", transform.position, 1.0f);
            Debug.Log("Ow");
        }
    }
}