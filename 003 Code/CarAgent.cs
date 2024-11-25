using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class CarAgent : Agent
{
    public Carcontroller carcontroller;
    public CheckpointManager checkpointmanager;
    private Rigidbody rb;
    private float lastDistanceToCheckpoint;
    private float lastSteer;
    private float movespeed = 4f;
  
    [SerializeField] private SpawnpointManager spawnpointmanager;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }


    public override void OnEpisodeBegin()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        if (spawnpointmanager != null)
        {
            spawnpointmanager.RandomSpawnpoint(transform);
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        Transform targetCheckpoint = checkpointmanager.GetCurrentCheckpoint();
        //Debug.Log($"good:{targetCheckpoint}");
        float distance = Vector3.Distance(transform.position, targetCheckpoint.position);
        sensor.AddObservation(distance);
        sensor.AddObservation(rb.linearVelocity);
        sensor.AddObservation(rb.angularVelocity);
        sensor.AddObservation(rb.linearVelocity.magnitude);
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetCheckpoint.localPosition);



    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        // 부드러운 회전값 계산
        float steer = actions.ContinuousActions[0];
        float move = actions.ContinuousActions[1];

       
        float adjustedSpeed = Mathf.Clamp(1f - Mathf.Abs(steer), 0.5f, 1f); // 회전이 클수록 속도 감소
        Debug.Log(steer);
        
        carcontroller.Steering(steer);
        carcontroller.Motor(move);
       
        

        Transform targetCheckpoint = checkpointmanager.GetCurrentCheckpoint();
        float distanceToCheckpoint = Vector3.Distance(transform.position, targetCheckpoint.position);
        Vector3 directionToCheckpoint = targetCheckpoint.position - transform.position;
        directionToCheckpoint.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(directionToCheckpoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * movespeed);
     
        /*
        RaycastHit hit;
        if (Physics.Raycast(transform.position, directionToCheckpoint.normalized, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Checkpoint"))
            {
                Debug.Log("체크포인트를 향해 이동 중...");
            }
        }*/
       



        if (distanceToCheckpoint < lastDistanceToCheckpoint)
        {
            float reward = Mathf.Max(0f, 1f / (distanceToCheckpoint + 1f));
            //Debug.Log($"dkwnwkfrkrhdlTdj~~~~~{reward}");
            AddReward(reward);
        }
        else
        {
            AddReward(-0.05f);
        }
        
       
        lastDistanceToCheckpoint = distanceToCheckpoint;


    }



    //Reward
    public float GetReward()
    {
        return GetCumulativeReward();
    }

    //TestAction
    public override void Heuristic(in ActionBuffers PassiveAction)
    {
        var Actionss = PassiveAction.ContinuousActions;

        Actionss[0] = Input.GetAxis("Horizontal");
        Actionss[1] = Input.GetAxis("Vertical");
    }


}
