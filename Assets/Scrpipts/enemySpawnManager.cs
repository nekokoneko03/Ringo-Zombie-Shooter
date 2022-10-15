using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnManager : MonoBehaviour
{
    public bool isSpawnEnebled = true;

    [Header("スポーンさせる敵のPrefabのリスト")]
    public List<Enemy> enemyPrefabs;

    [Header("スポーンさせたい位置のリスト")]
    public List<Transform> spawnPoints;

    private float timer;
    private float spawnTimer;

    private List<Enemy> spawnableEnemies;

    void Start()
    {
        timer = 0f;
        spawnableEnemies = new List<Enemy>();
    }

    void Update()
    {
        if (!isSpawnEnebled) return;

        timer += Time.deltaTime;

        // 1秒ごとに処理
        if (timer >= 1.0f)
        {
            spawnTimer += 1.0f;

            if (enemyPrefabs.Count > 0)
            {
                GetSpawnableEnemy(enemyPrefabs, spawnTimer);
            }

            if (spawnableEnemies.Count > 0)
            {
                SpawnEnemy(spawnableEnemies);
            }

            timer = 0f;
        }
    }

    void GetSpawnableEnemy(List<Enemy> enemyList, float spawnTimer)
    {
        foreach (Enemy enemy in enemyList)
        {
            CheckSpawnable(enemy, spawnTimer);
        }
    }

    void CheckSpawnable(Enemy enemy, float spawnTimer)
    {
        if (spawnTimer % enemy.status.spawnInterval == 0)
        {
            spawnableEnemies.Add(enemy);
        }
    }

    void SpawnEnemy(List<Enemy> spawnList)
    {
        foreach (Enemy enemy in spawnList)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Instantiate(enemy, spawnPoints[randomIndex].position, Quaternion.identity);
        }

        spawnableEnemies.Clear();
    }
}
