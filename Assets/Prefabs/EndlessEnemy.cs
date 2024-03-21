using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessEnemy : MonoBehaviour
{
    public GameObject enemyBullet;
    public GameObject explosion;

    public float speed;
    public int destroyScore;

    float timer;
    float firerate = 1.0f;

    private void Update()
    {
        timer += Time.deltaTime;

        this.transform.position += Vector3.down * speed * Time.deltaTime;

        if (timer >= firerate)
        {
           Invoke("FireBullet", 0.0f);
            timer = 0;
        }
    }

    void FireBullet()
    {
        GameObject player = GameObject.Find ("Player");

        if (player != null)
        {
            AudioSource fireSound = GameObject.Find("Fire Sound").GetComponent<AudioSource>();
            fireSound.Play();
            GameObject bullet = (GameObject)Instantiate(enemyBullet);
            bullet.transform.position = transform.position;
            Vector2 direction = player.transform.position - bullet.transform.position;
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            AudioSource deathSound = GameObject.Find("EnemyHit").GetComponent<AudioSource>();
            deathSound.Play();
            Instantiate(explosion, transform.position, Quaternion.identity);
            ScoreManager.instance.score += destroyScore;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
