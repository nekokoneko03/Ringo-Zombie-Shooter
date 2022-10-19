using System.Collections;
using UnityEngine;

public class shotController : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shotPoint;

    private BulletProperties bulletProperties;

    public float attackSpeedMultiplier;

    public bool canShot;

    void Start()
    {
        if (bulletPrefab != null)
        {
            bulletProperties = bulletPrefab.BulletStats;
        }
        canShot = true;
    }

    void Update()
    {
        Vector2 direction = GetKeyInput();

        if (canShot)
        {
            Shot(direction);
            StartCoroutine(ShotDelay(bulletProperties.shotDelay * attackSpeedMultiplier));
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
        // newBullet.damage = shotDamage;

        if (direction == Vector2.zero)
        {
            rb2d.velocity = Vector2.right * bulletProperties.bulletSpeed;
        }
        else
        {
            rb2d.velocity = direction * bulletProperties.bulletSpeed;
        }

        canShot = false;
    }

    public void ChangeBullet(Bullet bulletPrefab)
    {
        this.bulletPrefab = bulletPrefab;
    }

    IEnumerator ShotDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canShot = true;
    }
}
