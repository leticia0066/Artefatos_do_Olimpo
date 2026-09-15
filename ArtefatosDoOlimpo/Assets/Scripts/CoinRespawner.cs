
using UnityEngine;

public class CoinRespawner : MonoBehaviour
{
    private Coin[] coins;

    private void Awake()
    {
        // Procura todas as moedas da fase
        coins = FindObjectsOfType<Coin>(true);
    }

    public void RespawnAllCoins()
    {
        foreach (Coin coin in coins)
        {
            if (coin != null)
            {
                coin.Respawn();
            }
        }

        Debug.Log("Todas as moedas voltaram!");
    }
}
