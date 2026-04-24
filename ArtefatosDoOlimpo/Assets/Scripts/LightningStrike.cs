using UnityEngine;

public class LightningStrike : MonoBehaviour
{
    public int damage = 2;
    public float lifeTime = 0.4f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var p = collision.GetComponent<PlayerHealth>();
            if (p != null) p.TakeDamage(damage);
        }
    }
}