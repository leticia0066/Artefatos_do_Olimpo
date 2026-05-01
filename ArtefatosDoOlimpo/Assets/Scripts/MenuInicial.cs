using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("Fase1_Ares"); // nome da sua fase
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Saiu do jogo"); // só aparece no editor
    }
}