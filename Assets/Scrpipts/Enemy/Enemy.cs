using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Enemy Status")]
    public EnemyStatus status;
    public float currentHp;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentHp = status.maxHp;
    }

    protected void MoveToTarget()
    {
        this.transform.position = 
            Vector2.MoveTowards(this.transform.position, target.position, status.moveSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var target = collision.GetComponent<IDamageable>();

        if (target != null)
        {
            collision.GetComponent<IDamageable>().TakeDamage(status.attackDamage);
        }
    }

    public virtual void TakeDamage(float damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Destroy(this.gameObject);
    }

}
