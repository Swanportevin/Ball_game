using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] halfpipePrefabs; // Liste mit allen Prefabs
    public GameObject halfpipeInstance; // zuletzt initialisierte Halfpipe
    public Vector3 startSpawnPos; //SpawnPos für die ersten paar Halfpipes
    public Vector3 SpawnPos; //Spawn Pos für alle weiteren Halfpipes
    private ObjectMovement objectMovementScript;
    public Vector3 position; //Position der Halfpipe Instanz
    public float objectLength; //Länge der halfpipes


    public GameObject enemyPrefab;
    public float startDelay;


    void Start()
    {
        halfpipeInstance = SpawnStartHalfpipe(0f);
        //objectMovementScript = halfpipeInstance.GetComponent<ObjectMovement>();
        //objectLength = objectMovementScript.objectSize.z;
        SpawnStartHalfpipe(objectLength);
        SpawnStartHalfpipe(2*objectLength);
        halfpipeInstance = SpawnStartHalfpipe(3 * objectLength);
        Debug.Log(objectLength);

        InvokeRepeating("SpawnRandomEnemy", startDelay, Random.Range(2, 5));




    }


    void Update()
    {
        position = halfpipeInstance.transform.position;
        if (position.z < startSpawnPos.z+224) //Wenn Halfpipe Pos bestimmten Punkt unterschreitet, generiere Neue.
        {
            halfpipeInstance = SpawnRandomHalfpipe();
        }

        
    }

    GameObject SpawnStartHalfpipe(float objectLength)
    {
        halfpipeInstance = Instantiate(halfpipePrefabs[0], new Vector3(startSpawnPos.x, startSpawnPos.y, startSpawnPos.z + objectLength+3), halfpipePrefabs[0].transform.rotation);
        return halfpipeInstance;
    }

    GameObject SpawnRandomHalfpipe()
    {
        int halfpipeIndex = Random.Range(0, halfpipePrefabs.Length);
        halfpipeInstance = Instantiate(halfpipePrefabs[halfpipeIndex], SpawnPos, halfpipePrefabs[halfpipeIndex].transform.rotation);
        return halfpipeInstance;
    }

    void SpawnRandomEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(SpawnPos.x+Random.Range(-5, 5), SpawnPos.y+8, SpawnPos.z), enemyPrefab.transform.rotation);
    }

}

