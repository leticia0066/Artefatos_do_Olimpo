using UnityEngine;
using TMPro;
using System.Collections;

public class MedusaWarning : MonoBehaviour
{
    public GameObject warningText;
    public float displayTime = 3f;

    private bool hasShown = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasShown && collision.CompareTag("Player"))
        {
            hasShown = true;
            StartCoroutine(ShowWarning());
        }
    }

    IEnumerator ShowWarning()
    {
        warningText.SetActive(true);

        yield return new WaitForSeconds(displayTime);

        warningText.SetActive(false);
    }
}