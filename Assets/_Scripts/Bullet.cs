using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Alien
{
    public GameObject bulletGameObject;
    public Rigidbody2D bullet;
    public SpriteRenderer b;
    public float bulletSpeed = 2f;
    public int takeDamage = 20;


    private void Start()
    {
        Destroy(bulletGameObject, 2f);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            SpawnBullets();
        }
    }
    private void LateUpdate()
    {
        Shoot();
    }

    void Shoot()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);
        bullet.MovePosition(bullet.position + forward * Time.fixedDeltaTime * bulletSpeed);
    }

    void SpawnBullets()
    {
        Instantiate(bullet, shootDirection.transform.position, shootDirection.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(takeDamage);
            }
        }

        if (collision.tag == "BulletDestroy")
        {
            Destroy(this.gameObject);
        }
    }
}
