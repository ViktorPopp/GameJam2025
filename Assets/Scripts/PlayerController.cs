using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D _rigidbody;
    [SerializeField] private float _moveHorizontal;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");
        _rigidbody.linearVelocityX = _moveHorizontal * speed;
    }
}
