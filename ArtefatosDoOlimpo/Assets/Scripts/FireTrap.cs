using UnityEngine;

public class FireTrap : MonoBehaviour
{
    public float activeTime = 2f;
    public float inactiveTime = 2f;

    private bool isActive = true;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(FireCycle());
    }

    System.Collections.IEnumerator FireCycle()
    {
        while (true)
        {
            // 🔥 ativo
            isActive = true;
            sr.color = Color.red;

            yield return new WaitForSeconds(activeTime);

            // desligado
            isActive = false;
            sr.color = Color.gray;

            yield return new WaitForSeconds(inactiveTime);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isActive)
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(1);
            }
        }
    }
}