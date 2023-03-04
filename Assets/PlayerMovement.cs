using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb; // The player

    private Vector3 velocity = Vector3.zero; // Velocity of the player

    public Transform groundCheckRight; // The right leg
    public Transform groundCheckLeft; // The left leg

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    public float jumpForce;

    public float moveSpeed;

    private bool isJumping;
    public bool isGrounded;

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float horizontalMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if(Input.GetButtonDown("Jump") && isGrounded)
            isJumping = true;

        MovePlayer(horizontalMove);

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    private void MovePlayer(float horizontalMove){
        Vector3 targetVelocity = new Vector2(horizontalMove, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping){
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    private void Flip(float velocity){
        if(velocity > 0.1f){
            spriteRenderer.flipX = false;
        }else if(velocity < -0.1f){
            spriteRenderer.flipX = true;
        }
    }

}
