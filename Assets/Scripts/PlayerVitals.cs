using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVitals : MonoBehaviour, IDamageable
{
    [SerializeField] private Rigidbody2D bulletPrefab;
    public float DamagePower;
    [SerializeField] private float attackInterval;
    [SerializeField] private float maxHealth;
    [SerializeField] private float bulletSpeed;
    private float health;
    private float armor;
    private bool canShoot => Time.time >= nextShootTime;
    private float nextShootTime;

    void Awake()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!canShoot) return;
        nextShootTime = Time.time + attackInterval;
        var bullet = GameManager.Instance.Pooler.GetBullet(transform.position);
        bullet.transform.rotation = transform.rotation;
        bullet.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }

    public void Damage(float damage)
    {
        float armorToPercent = armor * 0.01f;
        float absorbedDamage = damage * armorToPercent;

        health -= (damage - absorbedDamage);
    }

    public void UpgradeMaxHealth()
    {
        float currentPercentage = health / maxHealth;
        print(currentPercentage);
        maxHealth += 100;
        health = maxHealth * currentPercentage;
        print($"current health is {health}, max health is{maxHealth}");
    }

    public void UpgradeDamage()
    {
        DamagePower += 30f;
    }

    public void UpgradeArmor()
    {
        armor += 10;
        armor = Mathf.Clamp(armor,0f,100f);
    }
}