using UnityEngine;

public class Minotaur : MonoBehaviour
{
    public int health = 5;

    public GameObject medalhao;

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

        if (medalhao != null)
        {
            medalhao.SetActive(true);
        }

        Destroy(gameObject);
    }
}