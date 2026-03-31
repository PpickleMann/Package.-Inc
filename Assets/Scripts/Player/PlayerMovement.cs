using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public MinigameManager minigameManager;

    public Rigidbody2D rb;

    private float speed = 8f;
    private float horizontal;

    public Animator animator;

    private bool right = true;

    void Update()
    {
        if (!minigameManager.inMinigame)
        {
            rb.linearVelocity = new Vector2(horizontal * speed, 0);

        if (horizontal != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        if (!right && horizontal > 0f)
        {
            Flip();
        }
        else if (right && horizontal < 0f)
        {
            Flip();
        }
        }
        else
        {
            rb.linearVelocity = new Vector2(0 , 0);
        }
    }

    private void Flip()
    {
        right = !right;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!minigameManager.inMinigame)
        {
        horizontal = context.ReadValue<Vector2>().x;
        }
        else
        {
            horizontal = 0;
        }
    }
}
