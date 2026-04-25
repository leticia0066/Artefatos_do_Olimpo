using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour
{
    public float upHeight = 1.5f;
    public float speed = 5f;
    public int damage = 1;
    public float delay = 1f;

    private Vector3 startPos;
    private Vector3 upPos;

    private bool activated = false;

    void Start()
    {
        startPos = transform.position;
        upPos = startPos + Vector3.up * upHeight;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated && collision.CompareTag("Player"))
        {
            activated = true;
            StartCoroutine(ActivateTrap());
        }
    }

    IEnumerator ActivateTrap()
    {
        // sobe
        while (Vector3.Distance(transform.position, upPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, upPos, speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(delay);

        // desce
        while (Vector3.Distance(transform.position, startPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            yield return null;
        }

        activated = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
}