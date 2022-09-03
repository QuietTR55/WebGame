using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPooler pooler;
    [SerializeField] private float spawnDistance;

    public float SpawnInterval;
    private bool canSpawn => Time.time >= nextSpawnTime;
    private float nextSpawnTime;
    private float timeElapsed;

    public bool GameStopped;

    void OnEnable()
    {

    }

    void OnDisable()
    {

    }

    void Update()
    {
        if(GameStopped) return;
        timeElapsed += Time.deltaTime;
        SpawnInterval -= Time.deltaTime * 0.001f;
        SpawnInterval = Mathf.Clamp(SpawnInterval, 0.1f, 10f);
        if (canSpawn)
        {
            SpawnEnemy(GetRandomPositionOnCircleOutline(transform.position));
            nextSpawnTime = Time.time + SpawnInterval;
        }
    }

    private void SpawnEnemy(Vector2 pos)
    {
        var enemy = pooler.GetEnemy();
        enemy.transform.position = pos;
    }

    private Vector3 GetRandomPositionOnCircleOutline(Vector2 origin)
    {
        float randomAngle = Random.Range(0, 360);
        float x = Mathf.Cos(randomAngle);
        float y = Mathf.Sin(randomAngle);
        Vector2 pos = new Vector2(x, y);
        return pos * spawnDistance;
    }

    private void StopSpawning()
    {
        GameStopped = true;
    }

    private void StartSpawning()
    {
        GameStopped = false;
    }
}
