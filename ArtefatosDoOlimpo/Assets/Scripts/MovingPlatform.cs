using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float speed = 2f;

    private Vector3 target;

    private Transform playerOnPlatform;

    void Start()
    {
        target = pointB.position;
    }

    void Update()
    {
        Vector3 oldPos = transform.position;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        Vector3 delta =
            transform.position - oldPos;

        // move o player junto horizontalmente
        if (playerOnPlatform != null)
        {
            playerOnPlatform.position += delta;
        }

        if (Vector3.Distance(
            transform.position,
            target
        ) < 0.1f)
        {
            target =
                target == pointA.position
                ? pointB.position
                : pointA.position;
        }
    }

    void OnCollisionEnter2D(
        Collision2D collision
    )
    {
        if (
            collision.gameObject.CompareTag(
                "Player"
            )
        )
        {
            playerOnPlatform =
                collision.transform;
        }
    }

    void OnCollisionExit2D(
        Collision2D collision
    )
    {
        if (
            collision.gameObject.CompareTag(
                "Player"
            )
        )
        {
            playerOnPlatform = null;
        }
    }
}