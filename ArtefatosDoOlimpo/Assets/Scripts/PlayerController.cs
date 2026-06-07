using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float speed = 8f;
    public float acceleration = 15f;
    public float jumpForce = 12f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Ataque")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private Rigidbody2D rb;
    private float moveInput;
    private float currentSpeed;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        Jump();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
        }
    }

    void FixedUpdate()
    {
        GroundCheck();
        Move();
    }

    // MOVIMENTO LISO
    void Move()
    {
        float targetSpeed = moveInput * speed;

        currentSpeed = Mathf.Lerp(
            currentSpeed,
            targetSpeed,
            acceleration * Time.fixedDeltaTime
        );

        rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);

        Flip();
    }

    // VIRA O PLAYER SEM ALTERAR ESCALA ORIGINAL
    void Flip()
    {
        if (moveInput == 0) return;

        Vector3 scale = transform.localScale;

        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(moveInput);

        transform.localScale = scale;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void GroundCheck()
    {
        if (groundCheck == null) return;

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
    }

    void Attack()
    {
        if (attackPoint == null) return;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRange,
            enemyLayers
        );

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject == gameObject)
                continue;

            enemy.SendMessage(
                "TakeDamage",
                1,
                SendMessageOptions.DontRequireReceiver
            );
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }

        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }
}