using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb; // The player

    private Vector3 velocity = Vector3.zero; // Velocity of the player

    public Transform groundCheckRight; // The right leg
    public Transform groundCheckLeft; // The left leg

    public float jumpForce;

    public float moveSpeed;

    private bool isJumping;
    public bool isGrounded;

    public AudioSource audioSource;
    public AudioClip audioClip;

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float horizontalMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if(Input.GetButtonDown("Jump") && isGrounded)
            isJumping = true;

        MovePlayer(horizontalMove);
    }

    private void MovePlayer(float horizontalMove){
        Vector3 targetVelocity = new Vector2(horizontalMove, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(!audioSource.isPlaying && horizontalMove!=0)audioSource.PlayOneShot(audioClip);
        if(isJumping){
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

}
