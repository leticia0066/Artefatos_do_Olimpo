using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Spawns")]
    public Transform startPoint;
    public Vector3 checkpointPosition;

    [Header("Vida")]
    public int maxHealth = 6;
    public int currentHealth;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 🔥 IMPORTANTE: não resetar entre fases
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (startPoint != null)
            checkpointPosition = startPoint.position;

        currentHealth = maxHealth; // vida começa cheia só 1 vez
    }

   

    public void SetCheckpoint(Vector3 pos)
    {
        checkpointPosition = pos;
    }

    public void ResetToStart()
    {
        if (startPoint != null)
            checkpointPosition = startPoint.position;
    }

    public Vector3 GetSpawnPosition()
    {
        return checkpointPosition;
    }

   

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}