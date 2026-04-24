using UnityEngine;

public class ZeusProjectile : MonoBehaviour
{
    public int damage = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var p = collision.GetComponent<PlayerHealth>();
            if (p != null) p.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}