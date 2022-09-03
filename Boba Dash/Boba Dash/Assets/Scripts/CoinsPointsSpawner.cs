using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPointsSpawner : MonoBehaviour
{
    //Handles the spawning of coins and points
    [SerializeField]
    private List<Spawn> items; //creates a list of Spawn items that can be spawned in
    private float nextSpawnTime;
    [SerializeField]
    private float spawnMinTime; //minimum time to spawn the next item
    [SerializeField]
    private float spawnMaxTime; //maximum time to spawn the next time
    void Start()
    {
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        if (nextSpawnTime <= 0) //when time hits zero, it's time to spawn another item!
        {
            SpawnObjects();
            nextSpawnTime = Random.Range(spawnMinTime, spawnMaxTime); //get another random spawn time
        }
        nextSpawnTime -= Time.deltaTime; //decrement the time if the time is not zero
    }
    void SpawnObjects() //each item has their own "spawn rate" (some items spawn more commonly than others)
    {
        int i = Random.Range(0, 100); //get a random integer
        for (int j = 0; j < items.Count; j++) //iterate through the list of Spawn items by index
        {
            if (i  >= items[j].minRange && i <= items[j].maxRange) //if the random integer is in the range of the item
            {
                Instantiate(items[j].spawnobject); //create (spawn) the item in the scene
                break; //break out of the entire for loop once successfully spawning in an item
            }
        }
    }
}
[System.Serializable]
public class Spawn
{
    //specifying a minRange and maxRange to determine the chances of spawning that item
    public GameObject spawnobject;
    public int minRange = 0;
    public int maxRange = 0;
}
