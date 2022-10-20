using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartObjectsSpawner : MonoBehaviour
{
    [Header("Instantiate objects in start")]
    public List<GameObject> objectsPrefabs = new List<GameObject>();

    public int objectsToSpawn;
    public float rateInMiddle; //0.0 - 1.0 Percentage of which the amount will be in the middle
    public float percentageMiddleSize; //0.0 - 1.0 Percentage of the size considered for middle

    private Vector3 centerOfSpawn;
    private float distanceFromCenterMin;
    private float distanceFromCenterMax;
    private float sizeZ;

    private Vector3 extends;
    private Vector3 bottomLeft;
    private Vector3 bottomRight;
    private Vector3 topLeft;
    private Vector3 topRight;

    // Start is called before the first frame update
    void Start()
    {
       
        centerOfSpawn = this.GetComponent<Renderer>().bounds.center;

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        extends = meshFilter.mesh.bounds.extents;
        bottomLeft = transform.TransformPoint(new Vector3(-extends.x, 0, -extends.z));
        bottomRight = transform.TransformPoint(new Vector3(extends.x, 0, -extends.z));
        topLeft = transform.TransformPoint(new Vector3(-extends.x, 0, extends.z));
        topRight = transform.TransformPoint(new Vector3(extends.x, 0, extends.z));

        sizeZ = topRight.z - bottomRight.z;

        rateInMiddle *= objectsToSpawn;

        rateInMiddle = (int)rateInMiddle;

        distanceFromCenterMin = centerOfSpawn.z - ((sizeZ / 2) * percentageMiddleSize);
        distanceFromCenterMax = centerOfSpawn.z + ((sizeZ / 2) * percentageMiddleSize);

        for (int i = 0; i < rateInMiddle; i++)
        {
            float posX = Random.Range(bottomLeft.x, topRight.x);
            float posZ = Random.Range(distanceFromCenterMin, distanceFromCenterMax);
            Vector3 pos = new Vector3(posX, centerOfSpawn.y, posZ);
            Instantiate(objectsPrefabs[Random.Range(0, objectsPrefabs.Count)], pos, Random.rotation);
        }

        objectsToSpawn -= (int)rateInMiddle;

        for (int i = 0; i < (objectsToSpawn / 2); i++)
        {
            float posX = Random.Range(bottomLeft.x, topRight.x);
            float posZ = Random.Range(bottomRight.z, distanceFromCenterMin);
            Vector3 pos = new Vector3(posX, centerOfSpawn.y, posZ);
            Instantiate(objectsPrefabs[Random.Range(0, objectsPrefabs.Count)], pos, Random.rotation);
        }

        for (int i = 0; i < (objectsToSpawn / 2); i++)
        {
            float posX = Random.Range(bottomLeft.x, topRight.x);
            float posZ = Random.Range(distanceFromCenterMax, topRight.z);
            Vector3 pos = new Vector3(posX, centerOfSpawn.y, posZ);
            Instantiate(objectsPrefabs[Random.Range(0, objectsPrefabs.Count)], pos, Random.rotation);
        }

    }
}
