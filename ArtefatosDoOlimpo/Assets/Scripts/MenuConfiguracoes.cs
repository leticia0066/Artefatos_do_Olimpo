using UnityEngine;

public class MenuConfiguracoes : MonoBehaviour
{
    public GameObject painelConfiguracoes;

    public void AbrirConfiguracoes()
    {
        painelConfiguracoes.SetActive(true);
    }

    public void FecharConfiguracoes()
    {
        painelConfiguracoes.SetActive(false);
    }
}