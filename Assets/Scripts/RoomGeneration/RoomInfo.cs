using UnityEngine;

public class RoomInfo : MonoBehaviour
{

    // cửa vào và ra
    public Transform entrance;
    public Transform exit;

    // kẻ thù và nơi spawn
    public Transform[] enemySpawnPoints;
    public bool hasSpawned = false;

    public void SpawnEnemies(GameObject[] enemyPrefabs)
    {
        if (hasSpawned || enemySpawnPoints == null || enemySpawnPoints.Length == 0) return; // Nếu đã spawn thì không spawn nữa
        foreach (Transform spawnPoint in enemySpawnPoints)
        {
            // Chọn ngẫu nhiên trong 1 loại quái trong mảng truyền vào
            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(randomEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        hasSpawned = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
