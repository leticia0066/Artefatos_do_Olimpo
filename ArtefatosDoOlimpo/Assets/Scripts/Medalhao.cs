using UnityEngine;

public class Medalhao : MonoBehaviour
{
    public GameObject door;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (door != null)
                door.SetActive(false);

            Destroy(gameObject);
        }
    }
}