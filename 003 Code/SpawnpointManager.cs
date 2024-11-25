using UnityEngine;

public class SpawnpointManager : MonoBehaviour
{
    public Transform[] spawnpoints;

    public void RandomSpawnpoint(Transform carTransform)
    {
        int randomIndex = Random.Range(0, spawnpoints.Length);
        Transform selectedSpawnPoint = spawnpoints[randomIndex];
        carTransform.position = selectedSpawnPoint.position;
        carTransform.rotation = selectedSpawnPoint.rotation;
    }
   
}
