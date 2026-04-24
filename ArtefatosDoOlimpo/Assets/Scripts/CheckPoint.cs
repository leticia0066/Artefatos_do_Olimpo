using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool activated = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated && collision.CompareTag("Player"))
        {
            activated = true;

            GameManager.instance.SetCheckpoint(transform.position);

            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}