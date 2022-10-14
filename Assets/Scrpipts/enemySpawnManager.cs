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

            CheckSpawnableEnemy();
            SpawnEnemy();

            timer = 0f;
        }
    }

    void CheckSpawnableEnemy()
    {
        foreach (Enemy enemy in enemyPrefabs)
        {
            if (spawnTimer % enemy.spawnTime == 0)
            {
                spawnableEnemies.Add(enemy);
            }
        }
    }

    void SpawnEnemy()
    {
        foreach (Enemy enemy in spawnableEnemies)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Instantiate(enemy, spawnPoints[randomIndex].position, Quaternion.identity);
        }

        spawnableEnemies.Clear();
    }
}
