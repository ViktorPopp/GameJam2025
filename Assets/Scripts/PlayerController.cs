using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Gun")]
    [SerializeField] private float distanceToCharacter = 1.5f;
    [SerializeField] private bool rapidFire = true;

    private Rigidbody2D _rigidbody;
    private Vector2 _movement;
    private Animator _animator;
    private GunController _gunController;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _gunController = GetComponentInChildren<GunController>();
    }

    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _movement.Normalize();

        _rigidbody.linearVelocity = _movement * moveSpeed;
        _animator.SetFloat("VelocityX", _rigidbody.linearVelocityX);
        _animator.SetFloat("VelocityY", _rigidbody.linearVelocityY);

       

        Vector2 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float _gunAngle = Vector2.SignedAngle(Vector2.left, (Vector2)transform.position - _mousePos);
        Vector3 _gunDirection = (transform.forward + new Vector3(Mathf.Cos(_gunAngle * Mathf.Deg2Rad), Mathf.Sin(_gunAngle * Mathf.Deg2Rad), 0)).normalized;
        _gunController.transform.position = _animator.transform.position + (_gunDirection * distanceToCharacter);
        _gunController.transform.eulerAngles = Vector3.forward * _gunAngle;
        _gunController.GetComponent<SpriteRenderer>().flipY = _gunAngle > 90 || _gunAngle < -90;

        if (rapidFire ? Input.GetMouseButton(0) : Input.GetMouseButtonDown(0))
        {
            _gunController.Shoot();
        }
    }

    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movement * moveSpeed * Time.fixedDeltaTime);
    }
}
