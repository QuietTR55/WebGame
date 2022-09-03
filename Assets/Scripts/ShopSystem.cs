using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public void BuyMaxHealthUpgrade()
    {
        GameManager.Instance.PlayerVital.UpgradeMaxHealth();
    }

    public void BuyDamageUpgrade()
    {
        GameManager.Instance.PlayerVital.UpgradeDamage();
    }

    public void BuyArmorUpgrade()
    {
        
    }
}
