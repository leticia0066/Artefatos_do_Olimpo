using UnityEngine;
using System.Collections;

public class ZeusWarning : MonoBehaviour
{
    public GameObject warningText;
    public float duration = 3f;

    private bool shown = false;

    void Start()
    {
        warningText.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!shown && collision.CompareTag("Player"))
        {
            shown = true;
            StartCoroutine(ShowWarning());
        }
    }

    IEnumerator ShowWarning()
    {
        warningText.SetActive(true);

        yield return new WaitForSeconds(duration);

        warningText.SetActive(false);
    }
}