using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float health = 3;

    public GameObject healthImage3;
    public GameObject healthImage2;
    public GameObject healthImage1;

    bool isInvincible;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            if (!isInvincible)
            {
                LoseHealth();
                Destroy(collision.gameObject);
            }   
        }
    }

    private void LoseHealth()
    {
        health--;
        Debug.Log(health);
    }

    private void Update()
    {
        if (health == 3)
        {
            healthImage3.SetActive(true);
            healthImage2.SetActive(true);
            healthImage1.SetActive(true);
        } else if (health == 2)
        {
            healthImage3.SetActive(false);
            healthImage2.SetActive(true);
            healthImage1.SetActive(true);
        } else if (health == 1)
        {
            healthImage3.SetActive(false);
            healthImage2.SetActive(false);
            healthImage1.SetActive(true);
        } else if (health == 0)
        {
            healthImage3.SetActive(false);
            healthImage2.SetActive(false);
            healthImage1.SetActive(false);
        }
    }
}
