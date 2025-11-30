using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D _rigidbody;
    private Vector2 _movement;
    private Animator _animator;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _movement.Normalize();

        _rigidbody.linearVelocity = _movement * moveSpeed;
        _animator.SetFloat("VelocityX", _rigidbody.linearVelocityX);
        _animator.SetFloat("VelocityY", _rigidbody.linearVelocityY);
    }

    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movement * moveSpeed * Time.fixedDeltaTime);
    }
}
