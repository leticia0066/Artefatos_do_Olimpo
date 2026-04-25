using UnityEngine;

public class Minotaur : MonoBehaviour
{
    public int health = 5;

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("Minotauro tomou dano! Vida: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Minotauro morreu!");
        Destroy(gameObject);
    }
}