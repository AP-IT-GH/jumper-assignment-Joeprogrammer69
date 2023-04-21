using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesPawner : MonoBehaviour
{
    public GameObject enemy;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(enemy);
    }
}
