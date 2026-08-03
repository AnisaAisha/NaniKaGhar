using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] Animator animator;
    [SerializeField] float speed;
    private Vector2 movement;
    private float paddingX = 0.035f; 
    private float paddingY = 0.075f; 

    // TODO: wait THIS UPDATE NEEDS TO BE REMOVED NO UPDATES IN ANY SCRIPTS
    // Also use FixedUpdate() instead of Update()
    void Update() {
        // Simple top-down movement
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");

        // Prevent diagonal movement
        // if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        // {
        //     movement.y = 0;
        // }
        // else
        // {
        //     movement.x = 0;
        // }

        // Convert Cartesian to Isometric movement (diagonal movement)
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement.x = x - y;
        movement.y = (x + y)/2;

        playerRigidbody.linearVelocity = movement * speed;
        animator.SetFloat("Speed", Mathf.Abs(movement.x));

        // Set parameters for player movement and idle blend trees in animator
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        if (movement != Vector2.zero) {
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);
        }

        // Confine the player within world bounds
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, paddingX, 1f - paddingX);
        pos.y = Mathf.Clamp(pos.y, paddingY, 1f - paddingY);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
