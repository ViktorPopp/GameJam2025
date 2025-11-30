using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private TMPro.TMP_Text lifeText;
    [SerializeField] private TMPro.TMP_Text scoreText;

    static public int score = 0;

    private Rigidbody2D _rigidbody;
    private Vector2 _movement;
    private Animator _animator;
    private int _health = 100;

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

        if (_health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        lifeText.text = "Health: " + _health;
        scoreText.text = "Score: " + score;
    }

    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player hit an enemy!");
            _health -= 2;
        }
        if (collision.gameObject.CompareTag("Rocket"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
