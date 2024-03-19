using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyBullet;

    public float speed;

    private void Update()
    {
        this.transform.position += Vector3.down * speed * Time.deltaTime;   
    }

    void FireBullet()
    {
        if (player != null)
        {
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
            InvokeRepeating("FireBullet", 0f, 1f);
        }
    }
}
