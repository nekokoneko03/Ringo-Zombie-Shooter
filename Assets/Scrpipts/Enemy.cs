using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public float spawnTime;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        this.transform.position = 
            Vector2.MoveTowards(this.transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
