using UnityEngine;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player player = collision.gameObject.GetComponentInParent<Player>();
            if (player != null)
            {
                player.setControllable(false);
                player.StopAllCoroutines();
                player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                player.GetComponent<Rigidbody2D>().angularVelocity = 0f;
                player.transform.rotation = Quaternion.identity;
                GameManager.instance.triggerWin();
            }
        }
    }
}
