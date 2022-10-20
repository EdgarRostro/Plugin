using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePlayerSpawn : MonoBehaviour
{

    public GameObject[] spawnLocation;
    public GameObject player;
    private Vector3 respawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        player = (GameObject)Resources.Load("Player", typeof(GameObject));
        spawnLocation = GameObject.FindGameObjectsWithTag("SpawnPoint");
        respawnLocation = player.transform.position;

        SpawnCharacter();
    }

   private void SpawnCharacter()
    {
        foreach (GameObject respawn in spawnLocation)
        {
            Instantiate(player, respawn.transform.position, respawn.transform.rotation);
        }
    }

   
}
