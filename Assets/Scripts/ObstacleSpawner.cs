using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Prefab مانع
    public float spawnIntervalZ = 5f; // فاصله بین موانع در محور Z
    public float spawnRangeX = 6f; // محدوده چپ و راست برای تولید
    public Transform player; // مرجع به کاراکتر یا مسیر (Cube)
    public float initialSpawnDistance = 20f; // فاصله اولیه اولین مانع از کاراکتر
    public int minimumObstacles = 20; // حداقل تعداد موانع در مسیر

    private List<GameObject> obstacles = new List<GameObject>(); // لیست موانع موجود

    void Start()
    {
        // تولید اولیه موانع
        for (int i = 0; i < minimumObstacles; i++)
        {
            SpawnObstacle(i * spawnIntervalZ + initialSpawnDistance);
        }
    }

    void Update()
    {
        // بررسی موانع و تولید موانع جدید در صورت نیاز
        MaintainObstacles();
    }

    void SpawnObstacle(float spawnZ)
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, 0.5f, spawnZ);
        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        obstacles.Add(newObstacle);
    }

    void MaintainObstacles()
    {
        // حذف موانع پشت بازیکن
        obstacles.RemoveAll(obstacle =>
        {
            if (obstacle.transform.position.z < player.position.z - 10f)
            {
                Destroy(obstacle);
                return true;
            }
            return false;
        });

        // تولید موانع جدید برای حفظ حداقل تعداد
        while (obstacles.Count < minimumObstacles)
        {
            float lastZ = obstacles.Count > 0 ? obstacles[obstacles.Count - 1].transform.position.z : player.position.z;
            SpawnObstacle(lastZ + spawnIntervalZ);
        }
    }
}
