using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManyPlayerSpawns : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject player;
    private Vector3 respawnLocation;

    private void Awake()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }
    void Start()
    {
        player = (GameObject)Resources.Load("Player", typeof(GameObject));
        respawnLocation = player.transform.position;
        SpawnPlayer();
    }
    
    private void SpawnPlayer()
    {
        int spawn = Random.Range(0, spawnLocations.Length);
        GameObject.Instantiate(player, spawnLocations[spawn].transform.position, Quaternion.identity);
    }
}
