
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool collected = false;

    private void Start()
    {
        // Guarda a posição original da moeda
        initialPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected)
            return;

        if (!other.CompareTag("Player"))
            return;

        Collect();
    }

    private void Collect()
    {
        collected = true;

        // Esconde a moeda
        gameObject.SetActive(false);

        Debug.Log("Moeda coletada!");
    }

    public void Respawn()
    {
        // Volta para a posição original
        transform.position = initialPosition;

        collected = false;

        // Faz a moeda aparecer novamente
        gameObject.SetActive(true);
    }
}

