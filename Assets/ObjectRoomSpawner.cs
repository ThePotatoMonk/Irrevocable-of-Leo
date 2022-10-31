using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRoomSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct RandomSpawner
    {
        
        // Variables
        public string name;
        public SpawnerData spawnerData;

    }

    public GridController grid;
    public RandomSpawner[] spawnerData;

    private void Start()
    {
 

    }

    void SpawnObjects(RandomSpawner data)
    {
        // Random number
        int randomNum = Random.Range(data.spawnerData.spawnMin, data.spawnerData.spawnMax + 1);
        
        for(int i = 0; i < randomNum; i++)
        {
            // Gets a random position on the grid
            int randomPos = Random.Range(0, grid.availablePoints.Count - 1);

            GameObject GridOffset = Instantiate(data.spawnerData.itemToSpawn, grid.availablePoints[randomPos], Quaternion.identity, transform) as GameObject;
            grid.availablePoints.RemoveAt(randomPos);
        }

    }

    // Spawn objects in
    public void InitaliseObject()
    {
        foreach(RandomSpawner rs in spawnerData)
        {
            SpawnObjects(rs);
        }
    }

}
