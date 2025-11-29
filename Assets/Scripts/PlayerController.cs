using System.ComponentModel;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Playermovement")]
    [SerializeField] private float acceleration = 2000.0f;
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float jumpForce = 10.0f;

    [Header("Gravity")]
    [SerializeField] private float normalGravity = 1f;
    [SerializeField] private float fallingGravity = 1.5f;

    [Header("Debug")]
    [SerializeField] private float debugHorizontalInput = 0;
    [SerializeField] private bool debugJump = false;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jump = Input.GetButtonDown("Jump");

        debugHorizontalInput = horizontalInput;
        debugJump = jump;

        rb.AddForceX(horizontalInput * acceleration * Time.deltaTime, ForceMode2D.Force);

        jump = Physics2D.Raycast(transform.position, Vector2.down).distance < 1 && jump;

        if (jump)
        {
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }



        if (rb.linearVelocityX > maxSpeed)
        {
            rb.linearVelocityX = maxSpeed;
        }
        rb.gravityScale = rb.linearVelocityY >= 0 /* positiv */ ? normalGravity : fallingGravity;
    }
}
