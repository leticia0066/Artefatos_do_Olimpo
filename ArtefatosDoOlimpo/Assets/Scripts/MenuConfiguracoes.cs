using UnityEngine;

public class MenuConfiguraçoes : MonoBehaviour
{
    public GameObject painel;


    public void AbrirPainel()
    {
        painel.SetActive(true);

        Time.timeScale = 0f;
    }


    public void FecharPainel()
    {
        painel.SetActive(false);

        Time.timeScale = 1f;
    }
}