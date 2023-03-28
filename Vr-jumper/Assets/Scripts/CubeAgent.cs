using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

using UnityEngine;

public class CubeAgent : Agent
{
    public Transform Target;
    public float speedMultiplier = 0.1f;
    public override void OnEpisodeBegin()
    {
        if (this.transform.localPosition.y < 0)
        {
            this.transform.localPosition = new Vector3(6, 0.5f, 0);
            this.transform.localRotation = Quaternion.identity;
        }


        Target.localPosition = new Vector3(Random.value * 8 - 4, 0.5f, Random.value * 8 - 4);
        speedMultiplier = Random.Range(0.1f,1f);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(Target.localPosition);
        sensor.AddObservation(this.transform.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Acties , size = 2
       Vector3 controlSignal = Vector3.zero;

        controlSignal.x = actionBuffers.ContinuousActions[0];
        controlSignal.z = actionBuffers.ContinuousActions[1];
        controlSignal.y = actionBuffers.ContinuousActions[2];
        transform.Translate(controlSignal * speedMultiplier);
        // Beloningen
        float distanceToTarget = Vector3.Distance(this.transform.position, Target.position);

        // target bereikt
        if (transform.position.y > Target.position.y + 0.2f)
        {
            SetReward(1.0f);
            EndEpisode();
            Debug.Log("hit");
        }
        
       

        // van het platform gevallen?
        else if (this.transform.localPosition.y < 0)
        {
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Vertical");
        continuousActionsOut[1] = Input.GetAxis("Horizontal");
        continuousActionsOut[2] = Input.GetAxis("Jump");
    }
}
