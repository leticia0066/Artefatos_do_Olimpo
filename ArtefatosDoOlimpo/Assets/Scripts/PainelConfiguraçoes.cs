using UnityEngine;

public class PainelConfiguracoes : MonoBehaviour
{
    public GameObject painelConfiguracoes;

    public void AbrirConfiguracoes()
    {
        Debug.Log("Botão clicado");
        painelConfiguracoes.SetActive(true);
    }

    public void FecharConfiguracoes()
    {
        painelConfiguracoes.SetActive(false);
    }
}