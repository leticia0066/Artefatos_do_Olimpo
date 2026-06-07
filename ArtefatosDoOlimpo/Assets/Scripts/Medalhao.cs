using UnityEngine;

public class Medalhao : MonoBehaviour
{
    public Door door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Medalhão coletado!");

            if (door != null)
            {
                door.OpenDoor();
            }

            Destroy(gameObject);
        }
    }
}