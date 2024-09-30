using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : MonoBehaviour
{
    public float difficulty = 2;
    public float spawnRange = 8;
    public Transform parent;
    public GameObject enemyPrefab;
    public bool canSpawn = false;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        Spawn(Random.Range(4, 10));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canSpawn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canSpawn = false;
        }
    }

    void Spawn(int enemies)
    {
        if (!canSpawn) return;
        for (int i = 0; i < enemies; i++)
        {
            Vector3 spawnPosition = new Vector3(
                transform.position.x + Random.Range(-spawnRange, spawnRange),
                transform.position.y + Random.Range(-spawnRange, spawnRange),
                transform.position.z
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
