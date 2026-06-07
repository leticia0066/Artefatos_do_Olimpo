using UnityEngine;

public class ForestEnemy : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();

            if (ph != null)
            {
                ph.TakeDamage(damage);
            }
        }
    }
}