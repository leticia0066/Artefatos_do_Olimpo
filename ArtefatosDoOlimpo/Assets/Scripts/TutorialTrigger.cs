using UnityEngine;
using System.Collections;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject tutorialText;
    public float duration = 4f;

    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated) return;

        if (collision.CompareTag("Player"))
        {
            activated = true;
            StartCoroutine(ShowTutorial());
        }
    }

    IEnumerator ShowTutorial()
    {
        tutorialText.SetActive(true);

        yield return new WaitForSeconds(duration);

        tutorialText.SetActive(false);

        Destroy(gameObject);
    }
}