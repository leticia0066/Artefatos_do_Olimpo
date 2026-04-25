using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 1f;
    public float respawnTime = 3f;

    private Rigidbody2D rb;
    private Vector3 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);

        rb.bodyType = RigidbodyType2D.Dynamic;

        yield return new WaitForSeconds(respawnTime);

        Respawn();
    }

    void Respawn()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;

        transform.position = startPos;
    }
}