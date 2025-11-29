using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 300f;

    private Rigidbody2D _rigidbody;
    private float _moveHorizontal;
    private bool _jump = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");
        _jump = Input.GetButtonDown("Jump") && (Physics2D.Raycast(transform.position, Vector2.down, 1, ~(1 << 6)).collider != null);
        if (_jump)
        {
            _rigidbody.AddForceY(jumpForce);
        }
    }

    void FixedUpdate()
    {
        _rigidbody.linearVelocityX = _moveHorizontal * speed;
        
    }
}
