using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [Header("Dano")]
    public int damage = 1; // 1 = meio coração

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        PlayerHealth player = collision.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}