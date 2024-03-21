using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayerController : MonoBehaviour
{
    public Projectile bullet;
    public Ultimate ult;

    public GameObject fire;

    public AudioSource fireAudio;
    public AudioSource ultAudio;

    public static int shotsFired;

    public static float speed = 5.0f;

    private bool isProjectileActive;

    public bool canMove = true;

    public static float firerate = 0.25f;

    float timer;

    public static bool moveUnlocked = false;
    public static bool canUseMove = false;

    private void Update()
    {
        timer += Time.deltaTime;

        if (canMove)
        {
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.position += Vector3.left * speed * Time.deltaTime;
                fire.SetActive(false);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.transform.position += Vector3.right * speed * Time.deltaTime;
                fire.SetActive(false);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                this.transform.position += Vector3.up * speed * Time.deltaTime;
                fire.SetActive(true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this.transform.position += Vector3.down * speed * Time.deltaTime;
                fire.SetActive(false);
            }
            else
            {
                fire.SetActive(false);
            }

            if (Input.GetKey(KeyCode.F))
            {
                if (timer >= firerate)
                {
                    Shoot();
                    timer = 0;
                }
            }

            if (shotsFired >= 20)
            {
                canUseMove = true;
                Debug.Log("Move Ready");
            }

            if (Input.GetKey(KeyCode.V))
            {
                if (moveUnlocked && canUseMove)
                {
                    UltimateMove();
                    ultAudio.Play();
                    canUseMove = false;
                    shotsFired = 0;
                }
            }
        }
    }

    private void Shoot()
    {
        if (!isProjectileActive)
        {
            fireAudio.Play();
            Projectile projectile = Instantiate(this.bullet, this.transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            isProjectileActive = true;
        }
    }

    private void UltimateMove()
    {
        if (!isProjectileActive)
        {
            Ultimate ultimate = Instantiate(this.ult, this.transform.position, Quaternion.identity);
            ultimate.destroyed += LaserDestroyed;
            isProjectileActive = true;
        }
    }

    private void LaserDestroyed()
    {
        isProjectileActive = false;
    }
}
