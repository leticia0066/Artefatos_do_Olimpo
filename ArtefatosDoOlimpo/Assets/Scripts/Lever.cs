using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject door;
    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated && collision.CompareTag("Player"))
        {
            activated = true;

            Debug.Log("Alavanca ativada!");

            if (door != null)
            {
                door.SetActive(false); // abre a porta
            }
        }
    }
}