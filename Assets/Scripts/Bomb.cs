using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed;

    public GameObject explosion;

    public AudioSource deathSound;

    public int destroyScore;

    void Update()
    {
        this.transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            deathSound.Play();
            Instantiate(explosion, transform.position, Quaternion.identity);
            ScoreManager.instance.score += destroyScore;
            Destroy(gameObject);
        }
    }
}
