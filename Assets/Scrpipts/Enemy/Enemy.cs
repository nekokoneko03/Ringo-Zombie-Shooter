using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stat")]
    public float maxHp = 0f;
    public float moveSpeed = 0f;
    public float spawnInterval = 0f;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected void MoveToTarget()
    {
        this.transform.position = 
            Vector2.MoveTowards(this.transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
