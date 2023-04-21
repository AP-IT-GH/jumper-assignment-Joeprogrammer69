using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Clone;
    private float InstantiationTimer = 3f;




    void Update()
    {
        CreatePrefab();
    }

    void CreatePrefab()
    {
        InstantiationTimer -= Time.deltaTime;
        if (InstantiationTimer <= 0)
        {
            Instantiate(Clone, transform.position, Quaternion.identity);
            InstantiationTimer = 3f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
    





