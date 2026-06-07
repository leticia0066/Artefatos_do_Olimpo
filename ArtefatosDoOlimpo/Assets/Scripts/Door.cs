using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public float moveDistance = 5f;
    public float speed = 2f;

    private bool opened = false;

    public void OpenDoor()
    {
        if (opened) return;

        opened = true;

        StartCoroutine(OpenAnimation());
    }

    IEnumerator OpenAnimation()
    {
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + Vector3.up * moveDistance;

        while (Vector3.Distance(transform.position, targetPos) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                speed * Time.deltaTime);

            yield return null;
        }
    }
}