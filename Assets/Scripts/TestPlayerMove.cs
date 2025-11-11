using UnityEngine;
using UnityEngine.InputSystem; // Import namespace baru

public class TestPlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = 0f;
        if (Keyboard.current.aKey.isPressed)
            horizontal = -1f;
        else if (Keyboard.current.dKey.isPressed)
            horizontal = 1f;

        body.linearVelocity = new Vector2(horizontal * speed, body.linearVelocity.y);

        // Ubah dari isPressed ke wasPressedThisFrame
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
    }
}
