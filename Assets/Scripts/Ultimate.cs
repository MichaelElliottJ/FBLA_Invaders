using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : MonoBehaviour
{
    public Vector3 direction;

    public float speed;

    public System.Action destroyed;

    BossManager bossManager;

    private void Update()
    {
        this.transform.position += this.direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boss")
        {
            bossManager = other.gameObject.GetComponent<BossManager>();
            bossManager.TakeDamage(10);
        }

        this.destroyed.Invoke();
        Destroy(this.gameObject);
    }
}
