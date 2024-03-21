using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyBullet;
    public GameObject explosion;

    public AudioSource deathSound;
    public AudioSource fireSound;

    public float speed;

    bool canShoot = false;

    public int destroyScore;

    float timer;
    float firerate = 1.0f;

    private void Update()
    {
        timer += Time.deltaTime;

        this.transform.position += Vector3.down * speed * Time.deltaTime;

        if (canShoot)
            if (timer >= firerate)
            {
                Invoke("FireBullet", 0.0f);
                timer = 0;
            }
    }

    void FireBullet()
    {
        if (player != null)
        {
            fireSound.Play();
            GameObject bullet = (GameObject)Instantiate(enemyBullet);
            bullet.transform.position = transform.position;
            Vector2 direction = player.transform.position - bullet.transform.position;
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Start")
        {
            canShoot = !canShoot;
        }

        if (collision.gameObject.tag == "Bullet")
        {
            deathSound.Play();
            Instantiate(explosion, transform.position, Quaternion.identity);
            ScoreManager.instance.score += destroyScore;
            Destroy(gameObject);
        }
    }
}
