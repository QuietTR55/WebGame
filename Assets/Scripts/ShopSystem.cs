using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopSystem : MonoBehaviour
{
    public uint Coins;

    public uint HealthUpgradeCost;
    public uint DamageUpgradeCost;
    public uint ArmorUpgradeCost;

    [SerializeField] private TMP_Text healthUpgradeCostText;
    [SerializeField] private TMP_Text damageUpgradeCostText;
    [SerializeField] private TMP_Text armorUpgradeCostText;

    [SerializeField] private TMP_Text coinsText;

    void Awake()
    {
        healthUpgradeCostText.text = "Buy : "+HealthUpgradeCost.ToString();
        damageUpgradeCostText.text = "Buy : "+DamageUpgradeCost.ToString();
        armorUpgradeCostText.text = "Buy : "+ArmorUpgradeCost.ToString();

        coinsText.text = Coins.ToString();
    }

    void OnEnable()
    {
    }

    void OnDisable()
    {
        GameManager.Instance.OnEnemyKilled -= OnEnemyKilled;
    }

    void Start()
    {
        GameManager.Instance.OnEnemyKilled += OnEnemyKilled;
    }

    public void BuyMaxHealthUpgrade()
    {
        if (Coins < HealthUpgradeCost) return;
        GameManager.Instance.PlayerVital.UpgradeMaxHealth();
        Coins -= HealthUpgradeCost;
        HealthUpgradeCost = (uint)(1.1f * HealthUpgradeCost);
        healthUpgradeCostText.text = "Buy : "+HealthUpgradeCost.ToString();
        coinsText.text = Coins.ToString();
    }

    public void BuyDamageUpgrade()
    {
        if (Coins < DamageUpgradeCost) return;
        GameManager.Instance.PlayerVital.UpgradeDamage();
        Coins -= DamageUpgradeCost;
        DamageUpgradeCost = (uint)(1.8f * DamageUpgradeCost);
        damageUpgradeCostText.text = "Buy : "+DamageUpgradeCost.ToString();
        coinsText.text = Coins.ToString();
    }

    public void BuyArmorUpgrade()
    {
        if (Coins < ArmorUpgradeCost) return;
        GameManager.Instance.PlayerVital.UpgradeArmor();
        Coins -= ArmorUpgradeCost;
        ArmorUpgradeCost = (uint)(ArmorUpgradeCost * 1.5f);
        armorUpgradeCostText.text = "Buy : "+ArmorUpgradeCost.ToString();
        coinsText.text = Coins.ToString();
    }

    public void BuyFirerateUpgrade()
    {

    }

    private void OnEnemyKilled()
    {
        Coins += 20;
        coinsText.text = Coins.ToString();
    }
}
