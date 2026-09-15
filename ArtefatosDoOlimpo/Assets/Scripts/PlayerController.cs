
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

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("ERRO: O Player não possui Rigidbody2D!");
        }

        if (groundCheck == null)
        {
            Debug.LogError("ERRO: GroundCheck não foi colocado no PlayerController!");
        }
    }

    void Update()
    {
        // Movimento horizontal
        moveInput = Input.GetAxisRaw("Horizontal");

        // Verifica se está no chão
        CheckGround();

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ESPAÇO PRESSIONADO | IsGrounded = " + isGrounded);

            if (isGrounded)
            {
                Jump();
            }
            else
            {
                Debug.LogWarning("PULO BLOQUEADO: o Player NÃO está sendo reconhecido no chão.");
            }
        }

        // Ataque
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
        if (rb == null)
            return;

        rb.linearVelocity = new Vector2(
            moveInput * speed,
            rb.linearVelocity.y
        );
    }

    void Jump()
    {
        if (rb == null)
            return;

        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            jumpForce
        );

        Debug.Log("PULO EXECUTADO!");
    }

    void CheckGround()
    {
        if (groundCheck == null)
        {
            isGrounded = false;
            return;
        }

        Collider2D ground = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        isGrounded = (ground != null);
    }

    void Flip()
    {
        if (moveInput == 0)
            return;

        Vector3 scale = transform.localScale;

        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(moveInput);

        transform.localScale = scale;
    }

    void Attack()
    {
        if (attackPoint == null)
            return;

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
        // GroundCheck
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;

            Gizmos.DrawWireSphere(
                groundCheck.position,
                groundCheckRadius
            );
        }

        // AttackPoint
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

