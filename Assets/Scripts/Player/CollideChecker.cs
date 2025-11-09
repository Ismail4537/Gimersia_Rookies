using UnityEngine;

public class CollideChecker : MonoBehaviour
{
    bool collide;
    protected Player player;
    void Awake()
    {
        player = GetComponentInParent<Player>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            collide = true;
            enterCondition();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            collide = false;
        }
    }

    protected virtual void enterCondition()
    {

    }

    public bool isCollide()
    {
        return collide;
    }
}