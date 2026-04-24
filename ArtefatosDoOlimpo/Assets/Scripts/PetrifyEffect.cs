using UnityEngine;
using System.Collections;

public class PetrifyEffect : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody2D rb;

    public float petrifyTime = 2f;
    private bool isPetrified = false;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Petrify()
    {
        if (isPetrified) return;

        StartCoroutine(PetrifyCoroutine());
    }

    IEnumerator PetrifyCoroutine()
    {
        isPetrified = true;

        Debug.Log("Player petrificado!");

        // trava movimento
        if (playerController != null)
            playerController.enabled = false;

        if (rb != null)
            rb.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(petrifyTime);

        // volta ao normal
        if (playerController != null)
            playerController.enabled = true;

        isPetrified = false;

        Debug.Log("Player voltou ao normal!");
    }
}