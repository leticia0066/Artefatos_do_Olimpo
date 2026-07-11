using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialPopup : MonoBehaviour
{
    [Header("Referências")]
    public CanvasGroup panel;
    public TMP_Text tutorialText;

    [Header("Mensagem")]
    [TextArea]
    public string message;

    [Header("Tempo")]
    public float fadeSpeed = 2f;
    public float showTime = 3f;

    private bool showed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (showed) return;

        if (collision.CompareTag("Player"))
        {
            showed = true;

            tutorialText.text = message;

            StartCoroutine(ShowTutorial());
        }
    }

    IEnumerator ShowTutorial()
    {
        // Fade In
        while(panel.alpha < 1)
        {
            panel.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        yield return new WaitForSeconds(showTime);

        // Fade Out
        while(panel.alpha > 0)
        {
            panel.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
}