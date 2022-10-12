using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.S))
            this.transform.position += Vector3.down * speed * Time.deltaTime;

        if(Input.GetKey(KeyCode.D))
            this.transform.position += Vector3.right * speed * Time.deltaTime; 
        
        if(Input.GetKey(KeyCode.W))
           this.transform.position += Vector3.up * speed * Time.deltaTime;

        if(Input.GetKey(KeyCode.A))
            this.transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
