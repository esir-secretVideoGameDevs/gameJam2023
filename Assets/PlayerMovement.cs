using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool isJumping;
    public bool isGrounded;

    public Transform groundCheckRight;
    public Transform groundCheckLeft;

    public float jumpForce;

    public float moveSpeed;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float horizontalMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if(Input.GetButtonDown("Jump") && isGrounded){
            isJumping = true;
        }

        MovePlayer(horizontalMove);
    }

    private void MovePlayer(float horizontalMove){
        Vector3 targetVelocity = new Vector2(horizontalMove, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping){
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

}
