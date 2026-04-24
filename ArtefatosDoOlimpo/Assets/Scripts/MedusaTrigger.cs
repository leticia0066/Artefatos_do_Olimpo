using UnityEngine;
using System.Collections;

public class MedusaTrigger : MonoBehaviour
{
    public GameObject warningText;
    public Medusa medusa;

    private bool activated = false;

    void Start()
    {
        if (warningText != null)
            warningText.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated && collision.CompareTag("Player"))
        {
            activated = true;
            StartCoroutine(StartFight());
        }
    }

    IEnumerator StartFight()
    {
        warningText.SetActive(true);
        yield return new WaitForSeconds(2f);
        warningText.SetActive(false);

        medusa.ActivateBoss();
    }
}