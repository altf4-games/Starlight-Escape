using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float difficulty = 1;
    public float spawnRange = 8;
    public Transform playerTransform;
    public Transform parent;
    public GameObject enemyPrefab;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        Spawn(Random.Range(4, 10));
    }

    void Spawn(int enemies)
    {
        for (int i = 0; i < enemies; i++)
        {
            Vector3 spawnPosition = new Vector3(
                playerTransform.position.x + Random.Range(-spawnRange, spawnRange),
                playerTransform.position.y + Random.Range(-spawnRange, spawnRange),
                playerTransform.position.z
            );
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, parent);
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(10 / difficulty);
            Spawn(Random.Range(3, 8));
            difficulty += 0.1f;
            difficulty = Mathf.Clamp(difficulty, 1, 10);
        }
    }

}
