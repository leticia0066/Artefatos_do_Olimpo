using UnityEngine;
using System.Collections;

public class LightningSpawner : MonoBehaviour
{
    public GameObject lightningPrefab;
    public GameObject warningPrefab;

    public float spawnInterval = 2f;
    public float rangeX = 8f;
    public float warningTime = 0.7f;
    public float spawnY = 5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnSequence), 1f, spawnInterval);
    }

    void SpawnSequence()
    {
        float x = Random.Range(-rangeX, rangeX);
        Vector3 pos = new Vector3(x, spawnY, 0);
        StartCoroutine(DoStrike(pos));
    }

    IEnumerator DoStrike(Vector3 pos)
    {
        // aviso
        GameObject w = null;
        if (warningPrefab != null)
            w = Instantiate(warningPrefab, new Vector3(pos.x, 0.5f, 0), Quaternion.identity);

        yield return new WaitForSeconds(warningTime);

        if (w != null) Destroy(w);

        // raio
        if (lightningPrefab != null)
            Instantiate(lightningPrefab, pos, Quaternion.identity);
    }
}