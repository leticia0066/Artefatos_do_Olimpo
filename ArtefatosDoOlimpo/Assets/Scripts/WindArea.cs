using UnityEngine;

public class WindArea : MonoBehaviour
{
    public float force = 10f;
    public Vector2 direction = Vector2.left;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.AddForce(direction * force);
            }
        }
    }
}