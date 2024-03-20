using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Projectile bullet;
    public Ultimate ult;

    public GameObject fire;

    public static int shotsFired;

    public static float speed = 5.0f;

    private bool isProjectileActive;

    public bool canMove = true;

    public static bool moveUnlocked = false;
    bool canUseMove = false;

    private void Update()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.position += Vector3.left * speed * Time.deltaTime;
                fire.SetActive(false);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.position += Vector3.right * speed * Time.deltaTime;
                fire.SetActive(false);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.position += Vector3.up * speed * Time.deltaTime;
                fire.SetActive(true);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.position += Vector3.down * speed * Time.deltaTime;
                fire.SetActive(false);
            }
            else
            {
                fire.SetActive(false);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                Shoot();
            }

            if (shotsFired >= 20)
            {
                canUseMove = true;
                Debug.Log("faals");
            }

            if (Input.GetKey(KeyCode.V))
            {
                if (moveUnlocked && canUseMove)
                {
                    UltimateMove();
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
