using UnityEngine;
using System.Collections;

public class MedusaTrigger : MonoBehaviour
{
    [Header("Boss")]
    public GameObject medusa;
    public GameObject bossDoor;

    [Header("UI (opcional)")]
    public GameObject warningText;

    private bool fightStarted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (fightStarted)
            return;

        StartCoroutine(StartFight());
    }

    IEnumerator StartFight()
    {
        fightStarted = true;

        // 🔥 trava entrada (opcional)
        if (bossDoor != null)
            bossDoor.SetActive(true);

        // ⚠️ aviso de batalha
        if (warningText != null)
            warningText.SetActive(true);

        yield return new WaitForSeconds(2f);

        if (warningText != null)
            warningText.SetActive(false);

        // 🐍 ativa medusa
        if (medusa != null)
            medusa.SetActive(true);
        else
            Debug.LogWarning("Medusa não foi atribuída no Inspector!");

        // 🚪 fecha arena (se quiser manter o player preso)
        if (bossDoor != null)
            bossDoor.SetActive(true);
    }
}