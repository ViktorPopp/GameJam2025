using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D _rigidbody;
    private Vector2 _movement;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            _movement = direction;
        }
        else
        {
            _movement = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movement * moveSpeed * Time.fixedDeltaTime);
    }
}
