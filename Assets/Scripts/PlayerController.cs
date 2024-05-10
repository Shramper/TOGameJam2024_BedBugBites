using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public float groundCheckRadius;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Vector3 localScale;

    private Rigidbody2D playerRB;

    void Start()
    {
        localScale = transform.localScale;
        playerRB = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Move();
        Jump();
    }

    void FixedUpdate()
    {
        FlipSprite();
    }

    void Move()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        playerRB.velocity = new Vector2(moveDirection * moveSpeed, playerRB.velocity.y);
    }

    private void Jump()
    {
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        }
    }

    void FlipSprite()
    {
        if (playerRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        }
        else if (playerRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
    }

    bool isGrounded()
    { 
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}
