using UnityEngine;
using System.Collections;

public class MiniBossTrigger : MonoBehaviour
{
    public GameObject minotauro;
    public GameObject warningText;

    private bool activated = false;

    void Start()
    {
        if (warningText != null)
            warningText.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated && collision.CompareTag("Player"))
        {
            activated = true;
            StartCoroutine(ActivateBoss());
        }
    }

    IEnumerator ActivateBoss()
    {
        warningText.SetActive(true);

        yield return new WaitForSeconds(2f);

        warningText.SetActive(false);

        minotauro.SetActive(true);
    }
}