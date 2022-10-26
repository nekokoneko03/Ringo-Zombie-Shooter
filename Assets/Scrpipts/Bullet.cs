using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletProperties bulletStats;
    [SerializeField] private OnHitEffect onHitEffect;

    public float damage;

    public Action OnHitEffect;
    public BulletProperties BulletStats { get => bulletStats; }

    private void Start()
    {
        if (onHitEffect != null)
        {
            OnHitEffect += onHitEffect.Effect;
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var target = collision.GetComponent<IDamageable>();

        if (target != null)
        {
            collision.GetComponent<IDamageable>().TakeDamage(bulletStats.attackDamage + damage);

            if (OnHitEffect != null)
            {
                OnHitEffect();
            }
        }
    }
}
