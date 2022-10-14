using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController: MonoBehaviour
{
    public float speed = 1.0f;

    public float blinkPower = 2.0f;

    public bool isBlink = false;
    private Vector2 blinkDir;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.down * speed * Time.deltaTime;
            blinkDir.y = Mathf.Clamp(-1, -1, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
            blinkDir.x = Mathf.Clamp(1, 0, 1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.up * speed * Time.deltaTime;
            blinkDir.y = Mathf.Clamp(1, 0, 1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
            blinkDir.x = Mathf.Clamp(-1, -1, 0);
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            blinkDir.y = 0f;
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            blinkDir.x = 0f;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (!isBlink)
            {
                Blink();
            }
        }
    }

    void Blink()
    {
        rb2d.AddForce(blinkDir * blinkPower, ForceMode2D.Impulse);
        StartCoroutine(StopBlink());
        isBlink = true;
    }

    IEnumerator StopBlink()
    {
        yield return new WaitForSeconds(0.35f);
        rb2d.velocity = Vector2.zero;
        StartCoroutine(BlinkDelay());
    }

    IEnumerator BlinkDelay()
    {
        yield return new WaitForSeconds(1.0f);
        isBlink = false;
    }
}
