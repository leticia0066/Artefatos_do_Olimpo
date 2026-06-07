using UnityEngine;

public class PlayerAttackHitbox : MonoBehaviour
{
    public int damage = 1;
    private bool active = false;

    public void Activate()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!active) return;

        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}