using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private bool thereIsGround = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        thereIsGround = true;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        thereIsGround = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        thereIsGround = false;
    }
    public bool isContact()
    {
        return thereIsGround;
    }
}
