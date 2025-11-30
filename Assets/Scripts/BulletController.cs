using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float lifeSpan = 10.0f;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        lifeSpan -= Time.deltaTime;

        if (lifeSpan <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 6)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
