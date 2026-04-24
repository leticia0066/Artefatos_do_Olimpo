using System.Collections;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    [Header("Referências")]
    public ParticleSystem lightning;
    public CameraShake cameraShake;

    [Header("Tempo entre tempestades")]
    public float minTime = 1f;
    public float maxTime = 3f;

    [Header("Quantidade de flashes")]
    public int minFlashes = 2;
    public int maxFlashes = 5;

    void Start()
    {
        StartCoroutine(LightningLoop());
    }

    IEnumerator LightningLoop()
    {
        while (true)
        {
            // espera tempo aleatório
            float wait = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(wait);

            // quantidade de relâmpagos seguidos
            int flashes = Random.Range(minFlashes, maxFlashes + 1);

            for (int i = 0; i < flashes; i++)
            {
                // ativa o raio
                lightning.Play();

                // treme a câmera
                if (cameraShake != null)
                    cameraShake.Shake();

                // pequeno intervalo entre flashes
                yield return new WaitForSeconds(Random.Range(0.1f, 0.25f));
            }
        }
    }
}