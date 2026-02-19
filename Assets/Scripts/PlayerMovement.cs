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


        // var leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(0,0)).x;
        // var rightBorder = Camera.main.ViewportToWorldPoint(new Vector2(1,0)).x;
        // var topBorder = Camera.main.ViewportToWorldPoint(new Vector2(0,0)).y;
        // var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector2(0,1)).y;

        // Vector3 playerSize = this.gameObject.GetComponent<Renderer>().bounds.size;

        // movement.x = Mathf.Clamp(movement.x, leftBorder + playerSize.x/2, rightBorder - playerSize.x/2);
        // movement.y = Mathf.Clamp(movement.y, topBorder + playerSize.y/2, bottomBorder - playerSize.y/2);

        playerRigidbody.linearVelocity = movement * speed;
        animator.SetFloat("Speed", Mathf.Abs(movement.x));

        // Set parameters for player movement and idle blend trees in animator
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        if (movement != Vector2.zero) {
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);
        }

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
