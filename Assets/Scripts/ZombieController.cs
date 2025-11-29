using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;

    [SerializeField] private Transform z_transform;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        z_transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player.position.x > z_transform.position.x)
        {
            rb.AddForce(new Vector2(moveSpeed, 0));
        }
        else if (player.position.x < z_transform.position.x)
        {
            rb.AddForce(new Vector2(-moveSpeed, 0));
        }
    }
}
