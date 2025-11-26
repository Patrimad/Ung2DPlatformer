using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Rigidbody2D rb;
    public float groundhCheckDistance = 0.1f;
    public float jumpForce = 5f;
    private float moveInput;
    public LayerMask groundLayer;
    public KeyCode jumpKey = KeyCode.Space;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(jumpKey) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundhCheckDistance, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * groundhCheckDistance,  Color.red);

        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
