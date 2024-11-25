using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckpointManager : MonoBehaviour
{
    public Transform[] checkpoints;
    private int currentcheckpointlist = 0;
    [SerializeField] private CarAgent caragent;


    public Transform GetCurrentCheckpoint()
    {
        return checkpoints[currentcheckpointlist];
    }

    public void PassCheckpoint()
    {
        if (currentcheckpointlist < checkpoints.Length - 1)
        {
            currentcheckpointlist++;
            caragent.AddReward(5.0f);
            caragent.GetReward();
            Debug.Log($"이건 체크포인트가 바뀔때마다 한 번만 나와야 합니다!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!{currentcheckpointlist}");
        }
        else
        {
            currentcheckpointlist = 0;
            if (caragent != null)
            {
                caragent.OnEpisodeBegin();
                Debug.Log("에피소드다시시작");
            }
        }
    }
    

   

    public bool IsCurrentCheckpoint(Transform checkpoint)
    {
        return GetCurrentCheckpoint() == checkpoint;
    }

    /*
    public Transform GetPreviousCheckpoint()
    {
        if (checkpointlist == 0)
        {
            return checkpoints[0];
        }
        else
        {
            return checkpoints[checkpointlist-1];
        }
     */

    

}

