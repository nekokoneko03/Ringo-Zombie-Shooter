using UnityEngine;

public class shotController : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shotPoint;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 direction = GetKeyInput();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shot(direction);
        }
    }

    Vector2 GetKeyInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        return new Vector2(x, y);
    }

    void Shot(Vector2 direction)
    {
        Bullet newBullet = Instantiate(bulletPrefab, shotPoint.position, Quaternion.identity);
        Rigidbody2D rb2d = newBullet.GetComponent<Rigidbody2D>();
        rb2d.velocity = direction * 1f; // 弾のステータスのスピードをかける
    }
}
