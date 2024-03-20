using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static float health = 3;

    public GameObject healthImage3;
    public GameObject healthImage2;
    public GameObject healthImage1;

    bool isInvincible;

    public SpriteRenderer playerRender;

    private void Start()
    {
        playerRender = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (health >= 3)
        {
            healthImage3.SetActive(true);
            healthImage2.SetActive(true);
            healthImage1.SetActive(true);
            health = 3;
        }
        else if (health == 2)
        {
            healthImage3.SetActive(false);
            healthImage2.SetActive(true);
            healthImage1.SetActive(true);
        }
        else if (health == 1)
        {
            healthImage3.SetActive(false);
            healthImage2.SetActive(false);
            healthImage1.SetActive(true);
        }
        else if (health <= 0)
        {
            SceneManager.LoadScene(6);
            health = 3;
        }
    }

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
        isInvincible = true;
        StartCoroutine("IFrames");
    }

    IEnumerator IFrames()
    {
        playerRender.material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        playerRender.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        yield return new WaitForSeconds(0.5f);
        playerRender.material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        playerRender.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        isInvincible = false;
    }
}
