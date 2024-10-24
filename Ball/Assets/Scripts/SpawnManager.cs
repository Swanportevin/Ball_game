using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] halfpipePrefabs; // Liste mit allen Prefabs
    public GameObject halfpipeInstance; // zuletzt initialisierte Halfpipe
    public GameObject Dollar; //Dollar
    public Vector3 startSpawnPos; //SpawnPos f�r die ersten paar Halfpipes
    public Vector3 SpawnPos; //Spawn Pos f�r alle weiteren Halfpipes
    private MeshRenderer instanceRenderer;
    private MeshRenderer prefabsRenderer;
    public float objectLength = 0f;

    public Vector3 position; //Position der Halfpipe Instanz

    private GameManager GameManager_script;
    public GameObject enemyPrefab;
    public GameObject MovingEnemy;
    public float startDelay;
    


    void Start()
    {
        GameManager_script = GameObject.Find("Game Manager").GetComponent<GameManager>();
        halfpipeInstance = SpawnStartHalfpipe(0f);
        instanceRenderer = halfpipeInstance.GetComponent<MeshRenderer>();
        objectLength = instanceRenderer.bounds.size.z;

        SpawnStartHalfpipe(objectLength);
        SpawnStartHalfpipe(2*objectLength);
        halfpipeInstance = SpawnStartHalfpipe(3 * objectLength);
        InvokeRepeating("SpawnObjects", startDelay, Random.Range(3, 6));
    }


    public void SpawnPipe()
    {
        position = halfpipeInstance.transform.position;
        instanceRenderer = halfpipeInstance.GetComponent<MeshRenderer>();
        objectLength = instanceRenderer.bounds.size.z;



        if (position.z < SpawnPos.z - objectLength + 4) //Wenn Halfpipe Pos bestimmten Punkt unterschreitet, generiere Neue.
        {
            halfpipeInstance = SpawnRandomHalfpipe();
        }

        
    }

    GameObject SpawnStartHalfpipe(float objectLength)
    {
        halfpipeInstance = Instantiate(halfpipePrefabs[0], new Vector3(startSpawnPos.x, startSpawnPos.y, startSpawnPos.z + objectLength+4), halfpipePrefabs[0].transform.rotation);
        return halfpipeInstance;
    }

    GameObject SpawnRandomHalfpipe()
    {
        int halfpipeIndex = Random.Range(0, halfpipePrefabs.Length);

        halfpipeInstance = Instantiate(halfpipePrefabs[halfpipeIndex], SpawnPos, halfpipePrefabs[halfpipeIndex].transform.rotation);

        return halfpipeInstance;
    }

    void SpawnObjects()
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

