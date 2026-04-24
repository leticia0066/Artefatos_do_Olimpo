using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject effect; // ← ESSE É O "Effect"

    private bool activated = false;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated && collision.CompareTag("Player"))
        {
            activated = true;

            // salva posição
            GameManager.instance.SetCheckpoint(transform.position);

            // muda cor
            sr.color = Color.green;

            // ativa efeito
            if (effect != null)
                effect.SetActive(true);
        }
    }
}