using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletProperties bulletStats;
    public BulletProperties BulletStats { get => bulletStats; }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var target = collision.GetComponent<IDamageable>();

        if (target != null)
        {
            // collision.GetComponent<IDamageable>().TakeDamage(damage);
        }
    }
}
