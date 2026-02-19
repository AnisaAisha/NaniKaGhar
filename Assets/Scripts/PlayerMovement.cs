using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
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

        playerRigidbody.linearVelocity = movement * speed;
        animator.SetFloat("Speed", Mathf.Abs(movement.x));

        // Set parameters for player movement and idle blend trees in animator
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        if (movement != Vector2.zero) {
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);
        }
    }
}
