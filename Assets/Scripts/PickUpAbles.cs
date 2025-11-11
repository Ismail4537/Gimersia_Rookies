using UnityEngine;

public class PickUpAbles : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        action();
        Destroy(this.gameObject);
    }

    protected void action()
    {

    }
}
