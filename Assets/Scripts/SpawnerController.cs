using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [Header("Spawn Rates")]
    [SerializeField] private float zombieSpawnRate = 1.0f;

    [Header("Prefabs")]
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private GameObject zombiePrefab;

    [Header("Zones")]
    [SerializeField] private GameObject rocketSpawnZone;
    [SerializeField] private GameObject rocketNonSpawnZone;
    [SerializeField] private GameObject zombieSpawnZone;
    [SerializeField] private GameObject zombieNonSpawnZone;

    private float timeSinceLastZombieSpawn = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rocketSpawnZone.SetActive(false);
        rocketNonSpawnZone.SetActive(false);
        zombieSpawnZone.SetActive(false);
        zombieNonSpawnZone.SetActive(false);

        SpawnRocket();
    }

    // Update is called once per frame
    void Update()
    {
        if  (timeSinceLastZombieSpawn <= 0)
        {
            timeSinceLastZombieSpawn = zombieSpawnRate;
            SpawnZombie();
        }
        else
        {
            timeSinceLastZombieSpawn -= Time.deltaTime;
        }
    }

    public GameObject SpawnRocket()
    {
        Vector2 spawnPos = Vector2.zero;
        
        while (true)
        {
            spawnPos = new Vector2(
                Random.Range(rocketSpawnZone.transform.position.x - (rocketSpawnZone.transform.localScale.x / 2), rocketSpawnZone.transform.position.x + (rocketSpawnZone.transform.localScale.x / 2)),
                Random.Range(rocketSpawnZone.transform.position.y - (rocketSpawnZone.transform.localScale.y / 2), rocketSpawnZone.transform.position.y + (rocketSpawnZone.transform.localScale.y / 2))
                );
            if (!IsInside(spawnPos, rocketNonSpawnZone.transform))
            {
                break;
            }
        }

        GameObject rocket = Instantiate(rocketPrefab, transform);
        rocket.transform.position = spawnPos;

        return rocket;
    }

    public GameObject SpawnZombie()
    {
        Vector2 spawnPos = Vector2.zero;

        while (true)
        {
            spawnPos = new Vector2(
                Random.Range(zombieSpawnZone.transform.position.x - (zombieSpawnZone.transform.localScale.x / 2), zombieSpawnZone.transform.position.x + (zombieSpawnZone.transform.localScale.x / 2)),
                Random.Range(zombieSpawnZone.transform.position.y - (zombieSpawnZone.transform.localScale.y / 2), zombieSpawnZone.transform.position.y + (zombieSpawnZone.transform.localScale.y / 2))
                );
            if (!IsInside(spawnPos, zombieNonSpawnZone.transform))
            {
                break;
            }
        }

        GameObject zombie = Instantiate(zombiePrefab, transform.parent);
        zombie.transform.position = spawnPos;

        return zombie;
    }

    private bool IsInside(Vector2 point, Transform transform)
    {
        return
            point.x > (transform.position.x - (transform.localScale.x / 2)) &&
            point.x < (transform.position.x + (transform.localScale.x / 2)) &&
            point.y > (transform.position.y - (transform.localScale.y / 2)) &&
            point.y < (transform.position.y + (transform.localScale.y / 2));
    }
}
