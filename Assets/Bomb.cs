using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed;

    public GameObject explosionAnim;

    void Update()
    {
        this.transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(explosionAnim, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
