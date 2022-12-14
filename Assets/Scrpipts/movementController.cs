using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;

    public float blinkPower = 2.0f;

    private PlayerStatus playerStatus;

    private bool isBlink = false;
    private Vector2 blinkDir;

    private Rigidbody2D rb2d;
    private SpriteRenderer playerRenderer;

    void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
        rb2d = this.GetComponent<Rigidbody2D>();
        playerRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.down * playerStatus.MovementSpeed * Time.deltaTime;

            playerAnim.SetFloat("Y", -1);

            blinkDir.y = Mathf.Clamp(-1, -1, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * playerStatus.MovementSpeed * Time.deltaTime;

            playerAnim.SetFloat("X", 1);

            playerRenderer.flipX = false;

            blinkDir.x = Mathf.Clamp(1, 0, 1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.up * playerStatus.MovementSpeed * Time.deltaTime;

            playerAnim.SetFloat("Y", 1);

            blinkDir.y = Mathf.Clamp(1, 0, 1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * playerStatus.MovementSpeed * Time.deltaTime;

            playerAnim.SetFloat("X", -1);

            playerRenderer.flipX = true;

            blinkDir.x = Mathf.Clamp(-1, -1, 0);
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            playerAnim.SetBool("Ringo Walk", false);
            playerAnim.SetBool("Ringo Idle", true);
        }
        else
        {
            playerAnim.SetBool("Ringo Walk", true);
            playerAnim.SetBool("Ringo Idle", false);
        }

        // ----------------Blink stuffs.------------------------

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

