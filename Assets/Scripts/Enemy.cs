using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float movementSpeed;
    public float MaxHealth;
    private float health;
    private PlayerVitals player;

    [SerializeField] private Rigidbody2D rb;

    void OnEnable()
    {
        health = MaxHealth;
        GameManager.Instance.OnWaveEnd += Cancel;
    }

    void OnDisable()
    {
        GameManager.Instance.OnWaveEnd -= Cancel;
    }

    void Start()
    {
        player = GameManager.Instance.PlayerVital;
    }
    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        transform.right = player.transform.position - transform.position;
        Vector2 dir = (player.transform.position - transform.position);
        dir = dir.normalized;
        rb.AddForce(dir * movementSpeed, ForceMode2D.Force);
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 2.5f)
        {
            player.Damage(20);
            gameObject.SetActive(false);
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        GameManager.Instance.OnEnemyKilled?.Invoke();
    }

    private void Cancel()
    {
        gameObject.SetActive(false);
    }
}
