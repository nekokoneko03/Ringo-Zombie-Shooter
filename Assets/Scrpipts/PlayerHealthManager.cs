using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHp;

    public float currentHp;

    private Action OnDeath;

    // getter
    public float MaxHp { get => maxHp; }

    private void Start()
    {
        currentHp = MaxHp;
        OnDeath = () => Destroy(this.gameObject);
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        OnDeath?.Invoke();
    }
}
