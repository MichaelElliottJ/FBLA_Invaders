using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Projectile bullet;

    public GameObject fire;

    public static float speed = 5.0f;

    private bool isProjectileActive;

    public bool canMove = true;

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
                Shoot();
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

    private void LaserDestroyed()
    {
        isProjectileActive = false;
    }
}
