using Unity.Mathematics;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform pivot;
    public Transform player;
    public GameObject bulletPrefab;
    public float radius;

    void Start()
    {
        transform.parent = pivot;
        transform.position += Vector3.up * radius;
    }

    void Update()
    {
        Vector3 playerVector = Camera.main.WorldToScreenPoint(player.position);
        playerVector = Input.mousePosition - playerVector;
        float angle = Mathf.Atan2(playerVector.y, playerVector.x) * Mathf.Rad2Deg;

        pivot.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (Input.GetMouseButtonDown(0))
        {
            Quaternion rotation = pivot.rotation * Quaternion.Euler(0, 0, 90);
            Instantiate(bulletPrefab, transform.position, rotation);
        }
    }
}
