using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> obstaclesPrefabs;  //A list of obstacle objects
    [SerializeField]
    private float spawnMinTime; //The minimum amount of time to wait before spawning an obstacle
    [SerializeField]
    private float spawnMaxTime; //The maximum amount of time to wait before spawning an obstacle
    private float nextSpawnTime; //The next time to spawn a obstacle

    // Start is called before the first frame update
    void Start()
    {
        Update();

    }

    // Update is called once per frame
    void Update()
    {

        int index = Random.Range(0, obstaclesPrefabs.Count); //get a random index in the range of the size of the list
        if (nextSpawnTime <= 0) //when time hits zero, it's time to spawn another item!
        {
            GameObject.Instantiate(obstaclesPrefabs[index], transform); //create (spawn) the obstacle in the scene
            nextSpawnTime = Random.Range(spawnMinTime, spawnMaxTime); //get another random spawn time
        }
        nextSpawnTime -= Time.deltaTime; //decrement the time if the time is not zero

    }
}
