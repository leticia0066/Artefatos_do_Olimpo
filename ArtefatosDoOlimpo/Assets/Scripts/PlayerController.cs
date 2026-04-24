using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float speed = 5f;
    public float jumpForce = 10f;

    [Header("Dash")]
    public float dashForce = 15f;
    private bool canDash = true;

    [Header("Ataque")]
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;
    private bool facingRight = true;

    private ShieldPower shield;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shield = GetComponent<ShieldPower>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        Jump();
        Dash();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
        }

        // 🛡️ ESCUDO (E)
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateShield();
        }

        Flip();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            float direction = facingRight ? 1f : -1f;

            rb.linearVelocity = new Vector2(direction * dashForce, 0);

            canDash = false;
            Invoke(nameof(ResetDash), 1f);
        }
    }

    void ResetDash()
    {
        canDash = true;
    }

    void Attack()
    {
        if (attackPoint == null) return;

        Collider2D[] hits = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRange,
            enemyLayer
        );

        foreach (Collider2D hit in hits)
        {
            hit.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        }
    }

    void ActivateShield()
    {
        if (shield != null)
        {
            shield.Activate();
        }
    }

    void Flip()
    {
        if (moveInput > 0 && !facingRight)
            FlipCharacter();
        else if (moveInput < 0 && facingRight)
            FlipCharacter();
    }

    void FlipCharacter()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}