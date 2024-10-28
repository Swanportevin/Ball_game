using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] halfpipePrefabs; // List with all halfpipe prefabs.
    public GameObject halfpipeInstance; // latest instantiated halfpipe.
    public GameObject Dollar; // dollar.
    public Vector3 startSpawnPos; // Spawn Pos for the first couple halfpipes.
    public Vector3 SpawnPos; // Spawn Pos for all new halfpipes.

    // Used to calculate the lengths of the halfpipes.
    private MeshRenderer instanceRenderer;
    private MeshRenderer prefabsRenderer;
    public float objectLength = 0f;

    public Vector3 position; // Position of the halfpipe instance.

    private GameManager GameManager_script;
    public GameObject enemyPrefab;
    public GameObject MovingEnemy;
    


    void Start()
    {
        GameManager_script = GameObject.Find("Game Manager").GetComponent<GameManager>();
        halfpipeInstance = SpawnStartHalfpipe(0f); // Sets the first halfpipe as the first instance.

        // Calculates the length of the first halfpipe.
        instanceRenderer = halfpipeInstance.GetComponent<MeshRenderer>();
        objectLength = instanceRenderer.bounds.size.z;

        SpawnStartHalfpipe(objectLength);
        SpawnStartHalfpipe(2*objectLength);
        halfpipeInstance = SpawnStartHalfpipe(3 * objectLength); // Sets last start halfpipe as the latest instance.
        InvokeRepeating("SpawnObjects", 5, Random.Range(3, 6)); // Spawns enemies and dollars every 3 to 6 sec.
    }


    public void SpawnPipe()
    {
        // Calculates length of the latest halfpipe.
        position = halfpipeInstance.transform.position;
        instanceRenderer = halfpipeInstance.GetComponent<MeshRenderer>();
        objectLength = instanceRenderer.bounds.size.z;



        if (position.z < SpawnPos.z - objectLength + 4) // Spawns a new halfpipe, after the latest instance goes below a certain point.
        {
            halfpipeInstance = SpawnRandomHalfpipe();
        }

        
    }

    GameObject SpawnStartHalfpipe(float objectLength)
    {
        halfpipeInstance = Instantiate(halfpipePrefabs[0], new Vector3(startSpawnPos.x, startSpawnPos.y, startSpawnPos.z + objectLength), halfpipePrefabs[0].transform.rotation);
        return halfpipeInstance;
    }

    GameObject SpawnRandomHalfpipe() // Spawns different halfpipes based on the list of prefabs.
    {
        int halfpipeIndex = Random.Range(0, halfpipePrefabs.Length);

        halfpipeInstance = Instantiate(halfpipePrefabs[halfpipeIndex], SpawnPos, halfpipePrefabs[halfpipeIndex].transform.rotation);

        return halfpipeInstance;
    }

    void SpawnObjects() // Spawns the enemies and dollars at variing positions.
    {
        if (GameManager_script.isGameActive)
        {
            if (Random.Range(1, 4) == 1)
            {
                Instantiate(MovingEnemy, new Vector3(SpawnPos.x, 12.32f , SpawnPos.z), enemyPrefab.transform.rotation);
            }
            else 
            { 
                Instantiate(enemyPrefab, new Vector3(SpawnPos.x + Random.Range(-8, 8), SpawnPos.y + 8, SpawnPos.z), enemyPrefab.transform.rotation);
            }
            Instantiate(Dollar, new Vector3(SpawnPos.x + Random.Range(-5, 5), SpawnPos.y + 5, SpawnPos.z - 50), Dollar.transform.rotation);
        }
        
    }

}

