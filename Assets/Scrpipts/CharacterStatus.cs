using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour, IBuffable
{

    public float maxHp;
    public float currentHp;
    public float attackDamage;
    public float movementSpeed;
    public bool immune;

    public float MaxHp { get => maxHp; set => maxHp = value; }
    public float CurrentHp { get => currentHp; set => currentHp = value; }
    public float AttackDamage { get => attackDamage; set => attackDamage = value; }
    public bool Immune { get => immune; set => immune = value; }
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }

    public virtual void Buff(StatusType statusType, float amount)
    {
        switch (statusType)
        {
            case StatusType.AttackDamage:
                AttackDamage += amount;
                break;
            case StatusType.movementSpeed:
                MovementSpeed += amount;
                break;
        }
    }

    public virtual void EndBuff(StatusType statusType, float amount)
    {
        switch (statusType)
        {
            case StatusType.AttackDamage:
                AttackDamage -= amount;
                break;
            case StatusType.movementSpeed:
                MovementSpeed -= amount;
                break;
        }
    }
}