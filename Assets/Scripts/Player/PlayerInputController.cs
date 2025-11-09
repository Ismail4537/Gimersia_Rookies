using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour

{
    public Vector2 dir = Vector2.zero;
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Debug.Log("Move started");
        }
        if (context.performed)
        {
            // Debug.Log("Move performed");
        }
        if (context.canceled)
        {
            // Debug.Log("Move canceled");
        }
        dir = context.ReadValue<Vector2>();
        // Debug.Log(dir);
    }

    public void JumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Debug.Log("Jump started");
        }
        if (context.performed)
        {
            if (player != null)
            {
                player.Jump();
            }
            // Debug.Log("Jump performed");
        }
        if (context.canceled)
        {
            // Debug.Log("Jump canceled");
        }
    }

    public void BoostInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Debug.Log("Boost started");
        }
        if (context.performed)
        {
            if (player != null)
            {
                player.useBooster();
            }
            // Debug.Log("Boost performed");
        }
        if (context.canceled)
        {
            // Debug.Log("Boost canceled");
        }
    }
}
