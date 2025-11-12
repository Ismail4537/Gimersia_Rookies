using UnityEngine;

public class CharCheck : CollideChecker
{
    GameObject fullCollider;

    protected override void doWhenAwake()
    {
        base.doWhenAwake();
        fullCollider = transform.Find("FullCollider").gameObject;
    }

    void Start()
    {
        if (fullCollider != null)
        {
            fullCollider.SetActive(false);
        }
    }
    protected override void enterTerrainCond()
    {
        SFXManager.instance.PlayClip3D("HitSnow", transform.position, 1.0f);
        fellOff();
    }

    protected override void enterObsCond()
    {
        SFXManager.instance.PlayClip3D("HitObstacle", transform.position, 1.0f);
        fellOff();
    }

    public void fellOff()
    {
        if (player.isFell)
        {
            return;
        }
        player.isFell = true;
        player.StopAllCoroutines();
        player.setControllable(false);
        fullCollider.transform.parent = null;
        transform.parent = null;

        gameObject.layer = LayerMask.NameToLayer("Default");
        transform.parent = fullCollider.transform;
        player.changeCamTarget(gameObject.transform);

        fullCollider.GetComponent<Rigidbody2D>().linearVelocity = player.getVelocity();

        if (fullCollider != null)
        {
            fullCollider.SetActive(true);
        }

        // trigger game over with 1 second delay
        Invoke("invokeGameOver", 1f);
    }

    void invokeGameOver()
    {
        GameManager.instance.triggerGameOver();
    }
}