using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayermask;
    private Vector2 lastPos;
    RaycastHit2D[] rayHit;
    ContactFilter2D filter;

    bool canStart;
    void Awake()
    {
        
    }
    void OnEnable()
    {
        canStart = false;
        Invoke("disable",4);
        lastPos = transform.position;
        canStart = true;
    }

    void OnDisable()
    {
        lastPos = Vector2.zero;
        canStart = false;
        CancelInvoke("disable");

    }

    void FixedUpdate()
    {
        if(!canStart) return;
        if(lastPos == Vector2.zero) return;
        filter.layerMask = enemyLayermask;
        filter.useLayerMask = true;
        RaycastHit2D hit = Physics2D.Linecast(lastPos, transform.position,enemyLayermask);
        if(hit.collider != null){
            var enemy = hit.collider.GetComponent<IDamageable>();
            enemy.Damage(GameManager.Instance.PlayerVital.DamagePower);
            gameObject.SetActive(false);
        }
    }

    private void disable (){
        gameObject.SetActive(false);
    }
}
