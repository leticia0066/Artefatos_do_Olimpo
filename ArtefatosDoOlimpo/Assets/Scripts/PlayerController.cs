using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float speed = 6f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Ataque")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    [Header("Dano por Queda")]
    public float minFallHeight = 5f;
    public int fallDamage = 1;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;

    private bool wasGrounded;
    private float highestY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        highestY = transform.position.y;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        CheckGround();

        // Guarda altura quando estiver no ar
        if (!isGrounded)
        {
            if (transform.position.y > highestY)
            {
                highestY = transform.position.y;
            }
        }

        // Caiu no chão
        if (!wasGrounded && isGrounded)
        {
            CheckFallDamage();
        }

        wasGrounded = isGrounded;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
        }

        Flip();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.linearVelocity =
            new Vector2(
                moveInput * speed,
                rb.linearVelocity.y
            );
    }

    void Jump()
    {
        highestY = transform.position.y;

        rb.linearVelocity =
            new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );
    }

    void CheckGround()
    {
        if (groundCheck == null)
        {
            isGrounded = false;
            return;
        }

        Collider2D ground =
            Physics2D.OverlapCircle(
                groundCheck.position,
                groundCheckRadius,
                groundLayer
            );

        isGrounded = (ground != null);
    }

    void CheckFallDamage()
    {
        float fallDistance =
            highestY - transform.position.y;

        if (fallDistance >= minFallHeight)
        {
            Debug.Log("Tomou dano por queda!");

            SendMessage(
                "TakeDamage",
                fallDamage,
                SendMessageOptions.DontRequireReceiver
            );
        }

        highestY = transform.position.y;
    }

    void Flip()
    {
        if (moveInput == 0)
            return;

        Vector3 scale = transform.localScale;

        scale.x =
            Mathf.Abs(scale.x)
            * Mathf.Sign(moveInput);

        transform.localScale = scale;
    }

    void Attack()
    {
        if (attackPoint == null)
            return;

        Collider2D[] hitEnemies =
            Physics2D.OverlapCircleAll(
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
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;

            Gizmos.DrawWireSphere(
                groundCheck.position,
                groundCheckRadius
            );
        }

        if (attackPoint != null)
        {
            Gizmos.color = Color.red;

            Gizmos.DrawWireSphere(
                attackPoint.position,
                attackRange
            );
        }
    }
}