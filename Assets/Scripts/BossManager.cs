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

    public Transform shootPos;

    public GameObject end;

    public AudioSource moveOneSound;
    public AudioSource moveTwoSound;

    public AudioSource deathSound;

    public GameObject ultIndicator;

    [Header("MOVE ONE")]
    public GameObject bulletOne;
    public GameObject bulletTwo;
    public GameObject bulletThree;
    public GameObject bulletFour;
    public GameObject bulletFive;

    [Header("MOVE TWO")]
    public GameObject leftLaser;
    public GameObject rightLaser;

    bool canShoot = true;

    int moveNumber;
    int i;

    float timer = 0;
    float cooldown;

    private void Start()
    {
        RandomCooldown();
    }

    private void Update()
    { 
        if (PlayerController.moveUnlocked)
            ultIndicator.SetActive(true);

        if (health <= 0)
        {
            StopAllCoroutines();
            leftLaser.SetActive(false);
            rightLaser.SetActive(false);

            StartCoroutine("Die");
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }

        if (canShoot)
        {
            timer += Time.deltaTime;

            if (timer >= cooldown)
            {
                GenerateRandomMove();
                if (moveNumber == 1)
                {
                    StartCoroutine("ShootMoveOne");
                }
                else if (moveNumber == 2)
                {
                    StartCoroutine("ShootMoveTwo");
                }
                timer = 0;
            }
        }
    }

    void GenerateRandomMove()
    {
        moveNumber = Random.Range(1, 3);
    }

    void RandomCooldown()
    {
        cooldown = Random.Range(5, 11);
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine("FlashDamage");
        health -= damage;
    }

    IEnumerator Die()
    {
        canShoot = false;
        deathSound.Play();
        bossAnim.SetBool("Death", true);
        end.SetActive(true);
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
        for (i = 0; i < 4; i++)
        {
            GameObject moveOne = (GameObject)Instantiate(bulletOne);
            GameObject moveTwo = (GameObject)Instantiate(bulletTwo);
            GameObject moveThree = (GameObject)Instantiate(bulletThree);
            GameObject moveFour = (GameObject)Instantiate(bulletFour);
            GameObject moveFive = (GameObject)Instantiate(bulletFive);

            moveOne.transform.position = shootPos.transform.position;
            moveTwo.transform.position = shootPos.transform.position;
            moveThree.transform.position = shootPos.transform.position;
            moveFour.transform.position = shootPos.transform.position;
            moveFive.transform.position = shootPos.transform.position;

            moveOneSound.Play();

            yield return new WaitForSeconds(1.5f);
        }

        i = 0;
    }

    IEnumerator ShootMoveTwo()
    {
        leftLaser.SetActive(true);
        rightLaser.SetActive(true);
        moveTwoSound.Play();

        yield return new WaitForSeconds(cooldown);

        leftLaser.SetActive(false);
        rightLaser.SetActive(false);
        moveTwoSound.Stop();
    }
}
