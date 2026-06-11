using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    public int maxHealth = 6; // 3 corações (6 meio corações)
    public int currentHealth;

    public event Action OnHealthChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        OnHealthChanged?.Invoke();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        currentHealth = maxHealth;
        transform.position = CheckpointManager.Instance.GetStartPosition();

        OnHealthChanged?.Invoke();
    }
}