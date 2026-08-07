using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    [Header("Fade")]
    public CanvasGroup fadePanel;
    public float fadeSpeed = 2f;

    private bool changingScene = false;

    private void Start()
    {
        // Se tiver painel de Fade configurado,
        // começa a cena com ele preto e depois clareia.
        if (fadePanel != null)
        {
            fadePanel.alpha = 1f;
            StartCoroutine(FadeIn());
        }
    }

    public void ChangeScene(string sceneName)
    {
        if (changingScene)
            return;

        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("ERRO: O nome da próxima cena está vazio!");
            return;
        }

        changingScene = true;

        Debug.Log("Indo para a cena: " + sceneName);

        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    private IEnumerator FadeIn()
    {
        while (fadePanel.alpha > 0f)
        {
            fadePanel.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }

        fadePanel.alpha = 0f;
    }

    private IEnumerator FadeOutAndLoad(string sceneName)
    {
        // Se não tiver FadePanel, carrega normalmente.
        if (fadePanel != null)
        {
            while (fadePanel.alpha < 1f)
            {
                fadePanel.alpha += Time.deltaTime * fadeSpeed;
                yield return null;
            }

            yield return new WaitForSeconds(0.2f);
        }

        // Confere se a cena existe no Build Profile
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError(
                "ERRO: A cena '" + sceneName +
                "' não está no Build Profile ou o nome está errado!"
            );

            changingScene = false;

            if (fadePanel != null)
                fadePanel.alpha = 0f;
        }
    }
}