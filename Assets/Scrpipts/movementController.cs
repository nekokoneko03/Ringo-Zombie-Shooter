using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController: MonoBehaviour
{
    [SerializeField] private Animator playerAnim;
  
    public float speed = 1.0f;

    public float blinkPower = 2.0f;

    private bool isBlink = false;
    private Vector2 blinkDir;

    private Rigidbody2D rb2d;
    private SpriteRenderer playerRenderer;

    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        playerRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.down * speed * Time.deltaTime;

            playerAnim.SetFloat("Y", -1);

            blinkDir.y = Mathf.Clamp(-1, -1, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;

            playerAnim.SetFloat("X", 1);

            playerRenderer.flipX = false;

            blinkDir.x = Mathf.Clamp(1, 0, 1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.up * speed * Time.deltaTime;

            playerAnim.SetFloat("Y", 1);

            blinkDir.y = Mathf.Clamp(1, 0, 1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;

            playerAnim.SetFloat("X", -1);

            playerRenderer.flipX = true;

            blinkDir.x = Mathf.Clamp(-1, -1, 0);
        }

        if (!Input.GetKey(KeyCode.W) &&!Input.GetKey(KeyCode.A)&&!Input.GetKey(KeyCode.S)&&!Input.GetKey(KeyCode.D))
        {
            playerAnim.SetBool("Walk Ringo",false);
            playerAnim.SetBool("Idle Ringo", true);

        }
        else
        {
            playerAnim.SetBool("Walk Ringo", true);
            playerAnim.SetBool("Idle Ringo", false);
        }

        // ----------------ÉuÉäÉìÉNópÇÃèàóù------------------------

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

