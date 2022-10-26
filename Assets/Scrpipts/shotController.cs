using System.Collections;
using UnityEngine;

public class shotController : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shotPoint;

    private BulletProperties bulletProperties;
    private PlayerStatus playerStatus;

    public bool canShot;

    void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
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
            StartCoroutine(ShotDelay((1f / (bulletProperties.attackSpeed * playerStatus.AttackSpeed))));
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
        canShot = false;
        float totalBulletCount = bulletProperties.bulletCount + playerStatus.bulletCount;
        float medianOfNum = Mathf.Lerp(1, totalBulletCount, 0.5f);
        
        for(int i = 0; i < totalBulletCount; i++)
        {
            
            Bullet newBullet = Instantiate(bulletPrefab, shotPoint.position, Quaternion.identity);
            Rigidbody2D rb2d = newBullet.GetComponent<Rigidbody2D>();

            Vector3 bulletAngle =
                Quaternion.Euler(new Vector3(0, 0,
                bulletProperties.bulletAngle * (medianOfNum - (totalBulletCount - i))
                )) * Vector2.up;

            rb2d.velocity = bulletAngle * bulletProperties.bulletSpeed * playerStatus.bulletSpeed;
            newBullet.transform.rotation = Quaternion.FromToRotation(Vector2.up, bulletAngle);
        }
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
