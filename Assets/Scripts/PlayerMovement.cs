using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] Animator animator;
    [SerializeField] float speed;
    private Vector2 movement;

    void Update() {
        // Simple top-down movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Prevent diagonal movement
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            movement.y = 0;
        }
        else
        {
            movement.x = 0;
        }

        // Flip sprite when moving left
        if (movement.x > 0) {
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0) {
            spriteRenderer.flipX = true;
        }

        playerRigidbody.linearVelocity = movement * speed;
        animator.SetFloat("Speed", Mathf.Abs(movement.x));

    }
}
