using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

using UnityEngine;
using UnityEngine.Analytics;

public class CubeAgent : Agent
{
    public Transform Target;
    private float speedMultiplier = 0.1f;
    public float force = 0.3f;
    public Transform reset = null;
    private bool OnFloor = false;
    
    
   

    
    public override void OnEpisodeBegin()
    {
        //ResetMyAgent();
        /*
        if (this.transform.localPosition.y < 0)
        {
            this.transform.localPosition = new Vector3(6, 0.5f, 0);
            this.transform.localRotation = Quaternion.identity;
        }
        */

        //Target.localPosition = new Vector3(Random.value * 8 - 4, 0.5f, Random.value * 8 - 4);
        GameObject obstacle = GameObject.FindGameObjectWithTag("enemy");
        speedMultiplier = Random.Range(0.1f,0.2f);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        
        sensor.AddObservation(Target.localPosition);
        sensor.AddObservation(this.transform.localPosition);
    }

    void IsOnFloor()
    {
        if (transform.position.y >= 0.1f)
        {
            OnFloor = true;
        }
    }
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        Vector3 controlSignal = Vector3.zero;

        controlSignal.y = actionBuffers.ContinuousActions[0] * 5f;
       
        transform.Translate(controlSignal * speedMultiplier);
        // Beloningen
        float distanceToTarget = Vector3.Distance(this.transform.position, Target.position);

        if (actionBuffers.DiscreteActions[0] == 1)
        {
            UpForce();
           
        }
       
        // target bereikt
        if (transform.position.y > Target.position.y + 0.2f && distanceToTarget < 0.22f)
        {
            SetReward(1.0f);
            EndEpisode();
            Debug.Log("successfull jump");
        }
        if (transform.position.y > Target.position.y)
        {
            SetReward(0.5f);
            EndEpisode();
        }
        if (transform.position.y > 3f)
        {
            ResetMyAgent();
            EndEpisode();
        }
        if (transform.position.y < 0f)
        {
            ResetMyAgent();
            EndEpisode();
        }


        if (distanceToTarget < 0.1f)
        {
            SetReward(-1.0f);
            EndEpisode();
            Debug.Log("Hit");
        }

        if (this.transform.position.y > 5f)
        {
            SetReward(-1.0f);
            EndEpisode();
        }

        // van het platform gevallen?
        else if (this.transform.localPosition.y < 0)
        {
            SetReward(-1.0f);
            EndEpisode();
        }
    }
    
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Jump");
       

    }
    
    private void UpForce()
    {
        if (OnFloor)
        {
            
            transform.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * force);
            OnFloor = false;
           
        }
           
        
       
    }
    
    private void ResetMyAgent()
    {
        this.transform.position = new Vector3(6.3f,0.5f,0);
    }
    
}
