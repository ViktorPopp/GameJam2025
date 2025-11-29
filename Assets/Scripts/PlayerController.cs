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

    private Rigidbody2D rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jump = Input.GetKeyDown(KeyCode.Space);

        rigidbody.AddForceX(horizontalInput * acceleration * Time.deltaTime, ForceMode2D.Force);


        if (jump)
        {
            rigidbody.AddForceY(jumpForce, ForceMode2D.Impulse);
        }



        if (rigidbody.linearVelocityX > maxSpeed)
        {
            rigidbody.linearVelocityX = maxSpeed;
        }
        rigidbody.gravityScale = rigidbody.linearVelocityY >= 0 /* positiv */ ? normalGravity : fallingGravity;
    }
}
