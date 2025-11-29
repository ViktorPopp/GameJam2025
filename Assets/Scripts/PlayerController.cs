using System.ComponentModel;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Playermovement")]
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 10.0f;

    [Header("Gravity")]
    [SerializeField] private float normalGravity = 1f;
    [SerializeField] private float fallingGravity = 1.5f;

    [Header("Debug")]
    [SerializeField] private float debugHorizontalInput = 0;
    [SerializeField] private bool debugJump = false;
    [SerializeField] private float debugRaycastDistance = 0;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jump = Input.GetButtonDown("Jump");

        debugHorizontalInput = horizontalInput;
        debugJump = jump;

        rb.linearVelocityX = horizontalInput * speed;

        debugRaycastDistance = Physics2D.Raycast(transform.position, Vector2.down).distance;
        jump = Physics2D.Raycast(transform.position, Vector2.down).distance < 1 && jump;

        if (jump)
        {
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
        rb.gravityScale = rb.linearVelocityY >= 0 /* positiv */ ? normalGravity : fallingGravity;
    }
}
