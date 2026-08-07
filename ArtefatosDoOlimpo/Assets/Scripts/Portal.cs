using UnityEngine;

public class Portal : MonoBehaviour
{
    [Header("Próxima cena")]
    public string nextSceneName;

    private bool playerEntered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerEntered)
            return;

        if (!collision.CompareTag("Player"))
            return;

        playerEntered = true;

        SceneTransition transition = GetComponent<SceneTransition>();

        if (transition != null)
        {
            transition.ChangeScene(nextSceneName);
        }
        else
        {
            Debug.LogError("ERRO: O Portal não possui o componente SceneTransition!");
        }
    }
}