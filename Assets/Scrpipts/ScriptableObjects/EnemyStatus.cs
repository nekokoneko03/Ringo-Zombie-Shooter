using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "ScriptableObject/New Enemy")]
public class EnemyStatus : ScriptableObject
{
    public string enemyName = "New enemy";
    public float maxHp = 0f;
    public float moveSpeed = 0f;
    public float spawnInterval = 0f;
    [TextArea]
    public string enemyDescription = "Enemy description.";
}
