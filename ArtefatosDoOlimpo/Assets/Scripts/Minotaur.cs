using UnityEngine;

public class Minotaur : MonoBehaviour
{
    public int health = 5;

    public void TakeDamage(int damage)
    {
        Debug.Log("MINOTAURO ACERTOU");

        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}