using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.SetCheckpoint(transform.position);
                Debug.Log("Checkpoint salvo");
            }
            else
            {
                Debug.LogError("GameManager não encontrado!");
            }
        }
    }
}