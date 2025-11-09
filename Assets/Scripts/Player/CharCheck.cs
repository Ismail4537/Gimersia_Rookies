using UnityEngine;

public class CharCheck : CollideChecker
{
    protected override void enterCondition()
    {
        SFXManager.instance.PlayClip3D("test", transform.position, 1.0f);
        Debug.Log("Owie");
    }
}