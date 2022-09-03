using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private int bulletPoolCount;
    [SerializeField] private int enemyPoolCount;
    private List<Rigidbody2D> bullets = new List<Rigidbody2D>();
    private List<Enemy> enemies = new List<Enemy>();
    void Start()
    {
        for (int i = 0; i < bulletPoolCount; i++)
        {
            Rigidbody2D bullet = Instantiate(bulletPrefab, transform);
            bullets.Add(bullet);
            bullet.gameObject.SetActive(false);
        }

        for (int i = 0; i < enemyPoolCount; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab, transform);
            enemies.Add(enemy);
            enemy.gameObject.SetActive(false);
        }
    }

    public Rigidbody2D GetBullet(Vector2 pos)
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].gameObject.activeSelf)
            {
                bullets[i].transform.position = pos;
                bullets[i].gameObject.SetActive(true);
                return bullets[i];
            }
        }

        Rigidbody2D bullet = Instantiate(bulletPrefab, transform);
        bullets.Add(bullet);
        bullet.transform.position = pos;
        return bullet;
    }

    public Enemy GetEnemy()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].gameObject.activeSelf)
            {
                enemies[i].gameObject.SetActive(true);
                return enemies[i];
            }
        }
        
        Enemy enemy = Instantiate(enemyPrefab, transform);
        enemies.Add(enemy);

        return enemy;

    }
}
