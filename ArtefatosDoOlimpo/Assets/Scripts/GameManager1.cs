using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Spawns")]
    public Transform startPoint;
    public Vector3 checkpointPosition;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        if (startPoint != null)
            checkpointPosition = startPoint.position;
    }

    public void SetCheckpoint(Vector3 pos)
    {
        checkpointPosition = pos;
    }

    public void ResetToStart()
    {
        if (startPoint != null)
            checkpointPosition = startPoint.position;
    }

    public Vector3 GetSpawnPosition()
    {
        return checkpointPosition;
    }
}