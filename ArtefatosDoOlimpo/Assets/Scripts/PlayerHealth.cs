using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 5;
    public int currentHealth;

    [Header("Vidas")]
    public int lives = 3;

    [Header("UI")]
    public HeartUI heartUI;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (heartUI == null)
            heartUI = FindFirstObjectByType<HeartUI>();

        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateUI();

        if (currentHealth <= 0)
        {
            lives--;

            if (lives > 0)
            {
                StartCoroutine(RespawnToCheckpoint());
            }
            else
            {
                StartCoroutine(RespawnToStart());
            }
        }
    }

    void UpdateUI()
    {
        if (heartUI != null)
            heartUI.UpdateHearts(lives);
    }

    IEnumerator RespawnToCheckpoint()
    {
        isDead = true;

        if (anim != null)
            anim.SetTrigger("Die");

        rb.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(0.6f);

        Vector3 pos = Vector3.zero;

        if (GameManager.instance != null)
            pos = GameManager.instance.GetSpawnPosition();

        transform.position = pos;

        currentHealth = maxHealth;

        UpdateUI();

        yield return new WaitForSeconds(0.2f);

        isDead = false;
    }

    IEnumerator RespawnToStart()
    {
        isDead = true;

        if (anim != null)
            anim.SetTrigger("Die");

        rb.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(0.8f);

        // 🔥 RESET TOTAL DE VIDAS
        lives = 3;
        currentHealth = maxHealth;

        Vector3 startPos = Vector3.zero;

        if (GameManager.instance != null)
        {
            GameManager.instance.ResetToStart();
            startPos = GameManager.instance.GetSpawnPosition();
        }

        transform.position = startPos;

        UpdateUI();

        yield return new WaitForSeconds(0.2f);

        isDead = false;
    }
}