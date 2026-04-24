using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Placa ativada!");
            door.SetActive(false); // abre
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Placa desativada!");
            door.SetActive(true); // fecha
        }
    }
}