using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SpawnManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject[] halfpipePrefabs; // Liste mit allen Prefabs
    public GameObject halfpipeInstance; // zuletzt initialisierte Halfpipe
    public GameObject Dollar; //Dollar
    public Vector3 startSpawnPos; //SpawnPos f�r die ersten paar Halfpipes
    public Vector3 SpawnPos; //Spawn Pos f�r alle weiteren Halfpipes
    private ObjectMovement objectMovementScript;
    public Vector3 position; //Position der Halfpipe Instanz
    public float objectLength; //L�nge der halfpipes

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
        InvokeRepeating("SpawnObjects", startDelay, Random.Range(2, 5));
    }


    public void SpawnPipe()
    {
        position = halfpipeInstance.transform.position;
        if (position.z < startSpawnPos.z+224 ) //Wenn Halfpipe Pos bestimmten Punkt unterschreitet, generiere Neue.
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

    void SpawnObjects ()
    {
        Instantiate(enemyPrefab, new Vector3(SpawnPos.x+Random.Range(-5, 5), SpawnPos.y+8, SpawnPos.z), enemyPrefab.transform.rotation);
        Instantiate(Dollar, new Vector3(0, 0, SpawnPos.z-50), Dollar.transform.rotation);
    }

}

