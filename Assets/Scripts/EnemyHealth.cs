using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerBullet")
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
