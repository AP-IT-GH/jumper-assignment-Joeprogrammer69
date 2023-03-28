using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobingObjectUp : MonoBehaviour
{
    public float min = 1f;
    public float max = 3f;
   
   

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(-16f,0.5f,-2);
        min = transform.position.y;
        max = transform.position.y + 3;

    }

    // Update is called once per frame
    void Update()
    {

         
        
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, max - min) + min, transform.position.x, transform.position.z) ;

    }
}
