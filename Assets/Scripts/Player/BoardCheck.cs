using UnityEngine;

public class BoardCheck : CollideChecker
{
    [SerializeField] CharCheck charCheck;
    protected override void enterTerrainCond()
    {
        if (player.transform.eulerAngles.z <= 300 && player.transform.eulerAngles.z >= 60 && !player.isGrounded)
        {
            SFXManager.instance.PlayClip3D("HitSnow", transform.position, 1.0f);
            charCheck.fellOff();
            changeLayer();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            if (player.getVelocity().magnitude > 1 && player.isGrounded)
            {
                SFXManager.instance.PlayClip3D("BoardSliding", transform.position, 1.0f);
            }
        }
    }

    protected override void enterObsCond()
    {
        SFXManager.instance.PlayClip3D("HitObstacle", transform.position, 1.0f);
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