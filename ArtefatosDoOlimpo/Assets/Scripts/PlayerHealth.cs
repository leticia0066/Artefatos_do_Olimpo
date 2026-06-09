using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public void TakeDamage(int damage)
    {
        GameManager.instance.TakeDamage(damage);

        if (GameManager.instance.IsDead())
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = GameManager.instance.GetSpawnPosition();

        GameManager.instance.ResetHealth(); // volta vida cheia no respawn
    }
}