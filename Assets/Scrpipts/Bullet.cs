using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var target = collision.GetComponent<IDamageable>();

        if (target != null)
        {
            collision.GetComponent<IDamageable>().TakeDamage(damage);
        }
    }
}
