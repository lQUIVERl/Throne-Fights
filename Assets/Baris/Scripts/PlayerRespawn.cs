using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private GameMaster gameMaster;

    private void Start()
    {
        gameMaster = GameMaster.instance;
        transform.position = gameMaster.GetLastCheckpointPos();
    }

    public void Respawn()
    {
        transform.position = gameMaster.GetLastCheckpointPos();
    }
}
