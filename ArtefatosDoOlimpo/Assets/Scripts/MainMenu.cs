using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene(1); // vai pra fase do jogo
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Saiu do jogo");
    }
}