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
        SFXManager.instance.PlayClip3D("test", transform.position, 1.0f);
        fellOff();
    }

    protected override void enterObsCond()
    {
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
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);

        if (fullCollider != null)
        {
            fullCollider.SetActive(true);
        }

        GameManager.instance.triggerGameOver();
    }
}