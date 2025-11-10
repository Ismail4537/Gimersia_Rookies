using UnityEngine;

public class CollideChecker : MonoBehaviour
{
    bool collide;
    protected Player player;
    void Awake()
    {
        doWhenAwake();
    }

    protected virtual void doWhenAwake()
    {
        player = GetComponentInParent<Player>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            collide = true;
            enterTerrainCond();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            enterObsCond();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            collide = false;
        }
    }

    protected virtual void enterTerrainCond()
    {

    }
    protected virtual void enterObsCond()
    {

    }

    public bool isCollide()
    {
        return collide;
    }
}