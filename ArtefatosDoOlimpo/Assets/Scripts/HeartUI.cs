using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public Image[] hearts;

    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    private PlayerHealth player;

    private void Start()
    {
        player = PlayerHealth.Instance;

        player.OnHealthChanged += UpdateHearts;

        UpdateHearts(); // atualiza no início
    }

    void UpdateHearts()
    {
        int health = player.currentHealth;

        for (int i = 0; i < hearts.Length; i++)
        {
            int heartValue = health - (i * 2);

            if (heartValue >= 2)
            {
                hearts[i].sprite = fullHeart;
            }
            else if (heartValue == 1)
            {
                hearts[i].sprite = halfHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}