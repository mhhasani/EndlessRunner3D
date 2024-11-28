using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Prefab مانع
    public float spawnInterval = 2f; // فاصله زمانی تولید
    public float spawnRangeX = 3f; // محدوده چپ و راست برای تولید
    public Transform player; // مرجع به کاراکتر یا مسیر (Cube)
    public float spawnOffset = 10f; // فاصله تولید مانع از کاراکتر

    void Start()
    {
        // شروع تولید موانع با فاصله زمانی
        InvokeRepeating("SpawnObstacle", 1f, spawnInterval);
    }

    void SpawnObstacle()
    {
        // موقعیت Z کاراکتر یا مسیر
        float spawnZ = player.position.z + spawnOffset;

        // موقعیت تصادفی برای مانع
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, 0.5f, spawnZ);

        // تولید مانع
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
