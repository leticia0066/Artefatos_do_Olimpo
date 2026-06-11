using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    public Vector3 currentCheckpointPosition;
    public Vector3 startPosition;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        startPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        currentCheckpointPosition = startPosition;
    }

    public void SetCheckpoint(Vector3 pos)
    {
        currentCheckpointPosition = pos;
        Debug.Log("Checkpoint salvo: " + pos);
    }

    public Vector3 GetRespawnPosition()
    {
        return currentCheckpointPosition;
    }

    public Vector3 GetStartPosition()
    {
        return startPosition;
    }
}