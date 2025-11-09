using UnityEngine;

public class PickUpAbles : MonoBehaviour
{
    Player player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            player = other.GetComponent<Player>();
        }
        else if (other.GetComponentInParent<Player>() != null)
        {
            player = other.GetComponentInParent<Player>();
        }
        else if (other.GetComponentInChildren<Player>() != null)
        {
            player = other.GetComponentInChildren<Player>();
        }
        if (player != null)
        {
            action(player);
            Destroy(this.gameObject);
        }
    }

    protected virtual void action(Player player)
    {
    }
}
