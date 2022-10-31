using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    public DungeonSpawnerData dungeonSpawnerData;
    private List<Vector2Int> dungeonRooms;

    public string[] EmptyRooms = { "Empty", "Shop", "Treasure"}; // List of possible rooms 

    
    private bool treasureSpawned;
    private bool shopSpawned;

    private void Start()
    {
        dungeonRooms = DungeonWalkerController.GenerateDungeon(dungeonSpawnerData);
        SpawnRooms(dungeonRooms);
    }

    // Spawns the rooms
    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        //When first loading it spawns the starting room
        RoomController.instance.LoadScene("Start", 0, 0);
        // Iterates through each room and spawns empty room in each location
        foreach (Vector2Int roomLocation in rooms)
        {
            RoomController.instance.LoadScene(GetRandomRoom(), roomLocation.x, roomLocation.y);  
        }
    }

    private string GetRandomRoom()
    {
        // Random number from 0-4
        int i = Random.Range(0, 5);

        // 1 in 5 chance for these two rooms to spawn
        if (i == 0 && !treasureSpawned)
        {
            treasureSpawned = true;
            return "Treasure";
        }
        else if(i == 1 && !shopSpawned)
        {
            shopSpawned = true;
            return "Shop";
        }
        
        // Other wise this spawns instead
        return "Empty";
    }

}

