using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManyPlayerSpawns : MonoBehaviour
{
    [Header("One or Many Spawners Player Settings")]
    public Transform[] spawnLocations;
    public GameObject player;
   
    void Start()
    {
        SpawnPlayer();
    }
    
    private void SpawnPlayer()
    {
        int spawn = Random.Range(0, spawnLocations.Length);
        Instantiate(player, spawnLocations[spawn].transform.position, Quaternion.identity);
    }
}
