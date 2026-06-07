using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;
    public GameObject warningText;

    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (activated)
            return;

        activated = true;

        if (door != null)
            door.SetActive(false);

        if (warningText != null)
        {
            warningText.SetActive(true);
            StartCoroutine(HideText());
        }
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(3f);

        if (warningText != null)
            warningText.SetActive(false);
    }
}