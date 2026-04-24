using UnityEngine;

public class Minotaur : MonoBehaviour
{
    [Header("Status")]
    public int health = 5;

    [Header("Movimento")]
    public float speed = 2f;
    public float detectionRange = 6f;

    [Header("Ataques")]
    public float chargeSpeed = 8f;
    public float attackCooldown = 3f;

    private Transform player;
    private Rigidbody2D rb;
    private bool isCharging = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating(nameof(ChargeAttack), 2f, attackCooldown);
    }

    void Update()
    {
        if (player == null) return;

        if (!isCharging)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance < detectionRange)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);
            }
        }
    }

    void ChargeAttack()
    {
        if (player == null) return;

        isCharging = true;

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * chargeSpeed, 0);

        Invoke(nameof(StopCharge), 1f);
    }

    void StopCharge()
    {
        isCharging = false;
    }

    // 👇 RECEBE DANO DO PLAYER
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Minotauro tomou dano!");

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