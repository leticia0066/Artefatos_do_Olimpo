using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 checkpointPosition;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(Vector3 pos)
    {
        checkpointPosition = pos;
        Debug.Log("Checkpoint salvo!");
    }

    public Vector3 GetCheckpoint()
    {
        return checkpointPosition;
    }
}