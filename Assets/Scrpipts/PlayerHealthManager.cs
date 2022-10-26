using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour, IDamageable
{
    private Action OnDeath;

    private PlayerStatus playerStatus;
    
    private void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
        playerStatus.CurrentHp = playerStatus.MaxHp;
        OnDeath = () => Destroy(this.gameObject);
    }

    public void TakeDamage(float damage)
    {
        playerStatus.CurrentHp -= damage;

        if (playerStatus.CurrentHp <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        OnDeath?.Invoke();
    }
}
