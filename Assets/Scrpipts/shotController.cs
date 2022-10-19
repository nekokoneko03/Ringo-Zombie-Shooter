using System.Collections;
using UnityEngine;

public class shotController : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private AudioSource shoot;

    public float shotSpeed;
    public float shotDelay;

    public bool canShot;

    void Start()
    {
        shoot = GetComponent<AudioSource>();
        canShot = true;
    }

    void Update()
    {
        Vector2 direction = GetKeyInput();

        if (canShot)
        {
            Shot(direction);
            StartCoroutine(ShotDelay(shotDelay));
        }
    }

    Vector2 GetKeyInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        return new Vector2(x, y).normalized;
    }

    void Shot(Vector2 direction)
    {
        Bullet newBullet = Instantiate(bulletPrefab, shotPoint.position, Quaternion.identity);
        Rigidbody2D rb2d = newBullet.GetComponent<Rigidbody2D>();

        if (direction == Vector2.zero)
        {
            rb2d.velocity = Vector2.right * shotSpeed;
        }
        else
        {
            rb2d.velocity = direction * shotSpeed; // 弾のステータスのスピードをかける
        }

        shoot.PlayOneShot(bulletPrefab.ShotSound);
        canShot = false;
    }

    IEnumerator ShotDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canShot = true;
    }
}
