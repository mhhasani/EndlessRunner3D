using UnityEngine;

public class PathSpawner : MonoBehaviour
{
    public GameObject pathPrefab; // Prefab مسیر
    public int numberOfPaths = 5; // تعداد مسیرهای اولیه
    public float pathLength = 10f; // طول هر مسیر

    private float spawnZ = 0f; // موقعیت Z برای تولید مسیرها

    void Start()
    {
        // تولید مسیرهای اولیه
        for (int i = 0; i < numberOfPaths; i++)
        {
            SpawnPath();
        }
    }

    public void SpawnPath()
    {
        // تولید مسیر جدید
        Instantiate(pathPrefab, new Vector3(0, 0, spawnZ), Quaternion.identity);
        spawnZ += pathLength; // حرکت به موقعیت Z بعدی
    }
}
