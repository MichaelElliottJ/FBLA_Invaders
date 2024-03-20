using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public int health;
    public SpriteRenderer sprite;
    public Animator bossAnim;

    public Rigidbody2D rb;

    public GameObject moveOne;

    public GameObject end;

    int moveNumber;

    float moveCountdown = 0;

    private void Start()
    {
        StartCoroutine("ShootMoveOne");
    }

    private void Update()
    {
        moveCountdown += Time.deltaTime;

        if (health <= 0)
        {
            StartCoroutine("Die");
        }
    }

    void GenerateRandomMove()
    {
        moveNumber = Random.Range(1, 3);
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine("FlashDamage");
        health -= damage;
    }

    IEnumerator Die()
    {
        bossAnim.SetBool("Death", true);
        end.SetActive(true);
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }

    IEnumerator FlashDamage()
    {
        sprite.material.color = new Color(1.0f, 1.0f, 1.0f, 0.75f);
        yield return new WaitForSeconds(0.1f);
        sprite.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    IEnumerator ShootMoveOne()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject move = (GameObject)Instantiate(moveOne);
            move.transform.position = this.transform.position;

            yield return new WaitForSeconds(1.5f);
        }
    }
}
