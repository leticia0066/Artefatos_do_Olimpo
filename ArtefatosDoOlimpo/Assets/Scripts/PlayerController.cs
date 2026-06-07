using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    public LayerMask groundLayer;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        Move();
        Jump();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Attack();
        }
    }

    void Move()
    {
        rb.linearVelocity =
            new Vector2(moveInput * speed, rb.linearVelocity.y);

        Vector3 scale = transform.localScale;

        if (moveInput > 0)
            scale.x = Mathf.Abs(scale.x);

        else if (moveInput < 0)
            scale.x = -Mathf.Abs(scale.x);

        transform.localScale = scale;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity =
                new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void Attack()
    {
        Debug.Log("ATACANDO");

        if (attackPoint == null)
            return;

        Collider2D[] hitEnemies =
            Physics2D.OverlapCircleAll(
                attackPoint.position,
                attackRange,
                enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            // NÃO deixa o player atacar ele mesmo
            if (enemy.gameObject == gameObject)
                continue;

            Debug.Log("Acertou: " + enemy.name);

            enemy.SendMessage(
                "TakeDamage",
                1,
                SendMessageOptions.DontRequireReceiver);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
            attackPoint.position,
            attackRange);
    }
}