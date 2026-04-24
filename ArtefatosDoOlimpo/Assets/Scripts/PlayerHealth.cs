using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int health;

    public int lives = 3;

    public PlayerHealthBar healthBar;
    public GameObject gameOverUI;

    void Start()
    {
        health = maxHealth;
        if (healthBar != null) healthBar.SetMax(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (healthBar != null) healthBar.Set(health);

        if (health <= 0)
        {
            LoseLife();
        }
    }

    void LoseLife()
    {
        lives--;

        if (lives > 0)
        {
            Respawn();
        }
        else
        {
            StartCoroutine(GameOver());
        }
    }

    void Respawn()
    {
        Vector3 respawn = GameManager.instance.GetCheckpoint();
        transform.position = respawn;

        health = maxHealth;
        if (healthBar != null) healthBar.Set(health);
    }

    IEnumerator GameOver()
    {
        if (gameOverUI != null) gameOverUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Fase1");
    }
}