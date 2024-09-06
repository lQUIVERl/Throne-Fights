using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    private Vector2 lastCheckpointPos;

    private void Awake()
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

    public void SetCheckpoint(Vector2 newCheckpointPos)
    {
        lastCheckpointPos = newCheckpointPos;
    }

    public Vector2 GetLastCheckpointPos()
    {
        return lastCheckpointPos;
    }
}
