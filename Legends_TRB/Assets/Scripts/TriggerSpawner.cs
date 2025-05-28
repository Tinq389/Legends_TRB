using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : Spawner
{
    private bool hasSpawned = false;

    public override void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasSpawned)
        {
            hasSpawned = true;
            StartSpawn();
        }
    }
}
