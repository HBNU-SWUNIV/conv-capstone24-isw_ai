using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private CheckpointManager checkpointManager;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter triggered");
        if (other.CompareTag("Car"))
        {
            if (checkpointManager.IsCurrentCheckpoint(transform))
            {
                checkpointManager.PassCheckpoint();
            }
            else
            {
                Debug.Log("잘못된 체크");
            }
        }
    }
}
