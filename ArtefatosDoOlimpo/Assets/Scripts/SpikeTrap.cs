using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public int damage = 1; // 1 = meio coração

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.Instance.TakeDamage(damage);
        }
    }
}