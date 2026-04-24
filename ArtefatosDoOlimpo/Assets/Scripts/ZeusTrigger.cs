using UnityEngine;

public class ZeusTrigger : MonoBehaviour
{
    public GameObject zeus;
    public GameObject healthBar;
    public GameObject lightningManager;

    private bool activated = false;

    void Start()
    {
        if (zeus != null) zeus.SetActive(false);
        if (healthBar != null) healthBar.SetActive(false);
        if (lightningManager != null) lightningManager.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated && collision.CompareTag("Player"))
        {
            activated = true;

            if (zeus != null) zeus.SetActive(true);
            if (healthBar != null) healthBar.SetActive(true);
            if (lightningManager != null) lightningManager.SetActive(true);

            Debug.Log("⚡ Zeus apareceu!");
        }
    }
}