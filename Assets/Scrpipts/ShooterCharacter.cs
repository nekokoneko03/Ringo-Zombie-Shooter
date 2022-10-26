using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(shotController))]
public class ShooterCharacter : CharacterStatus
{
    [Header("Shooter Properties")]
    public float attackSpeed;
    public float bulletCount;
    public float bulletSpeed;
    public float bulletPenetration;

    private shotController shotController;

    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public float BulletileSpeed { get => bulletSpeed; set => bulletSpeed = value; }
    public float BulletCount { get => bulletCount; set => bulletCount = value; }
    public float BulletPenetration { get => bulletPenetration; set => bulletPenetration = value; }

    private void Start()
    {
        shotController = GetComponent<shotController>();
    }

    public override void Buff(StatusType statusType, float amount)
    {
        switch (statusType)
        {
            case StatusType.AttackSpeed:
                attackSpeed += amount;
                break;
            case StatusType.BulletCount:
                bulletCount += amount;
                break;
            case StatusType.BulletSpeed:
                bulletSpeed += amount;
                break;
            case StatusType.BulletPenetration:
                bulletPenetration += amount;
                break;
        }
    }

    public override void EndBuff(StatusType statusType, float amount)
    {
        switch (statusType)
        {
            case StatusType.AttackSpeed:
                attackSpeed -= amount;
                break;
            case StatusType.BulletCount:
                bulletCount -= amount;
                break;
            case StatusType.BulletSpeed:
                bulletSpeed -= amount;
                break;
            case StatusType.BulletPenetration:
                bulletPenetration -= amount;
                break;
        }
    }
}
