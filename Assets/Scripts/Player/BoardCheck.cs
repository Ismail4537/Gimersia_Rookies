using UnityEngine;

public class BoardCheck : CollideChecker
{
    [SerializeField] CharCheck charCheck;
    protected override void enterTerrainCond()
    {
        if (player.transform.eulerAngles.z <= 300 && player.transform.eulerAngles.z >= 60 && !player.isGrounded)
        {
            SFXManager.instance.PlayClip3D("test", transform.position, 1.0f);
            charCheck.fellOff();
            changeLayer();
        }
    }

    protected override void enterObsCond()
    {
        SFXManager.instance.PlayClip3D("test", transform.position, 1.0f);
        charCheck.fellOff();
        changeLayer();
    }

    void changeLayer()
    {
        if (player.isFell)
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}